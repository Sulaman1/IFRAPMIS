using DAL.Models.Domain.MasterSetup;
using DAL.Models;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BAL.IRepository.SocialMobilization;
using DAL.Models.Domain.SocialMobilization;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services.SocialMobilization
{
    public class CICIGMemberService: ICICIGMember
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CICIGMemberService(
          ApplicationDbContext context,
          UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        public void Remove(CIMember communityInstituteMember)
        {
            this._context.Remove<CIMember>(communityInstituteMember);
            this._context.SaveChanges();
        }

        //public async Task<List<CIMember>> GetAll() => await _context.CIMembers.Include<CIMember, CICIG>((Expression<Func<CIMember, CICIG>>)(c => c.CICIG)).Include<CIMember, Designation>((Expression<Func<CIMember, Designation>>)(a => a.Designation)).ToListAsync<CIMember>();
        public async Task<List<CIMember>> GetAll()
        {
            return await _context.CIMembers.ToListAsync();
        }
        public List<CICIG> GetAllCI() => _context.CICIGs.ToList<CICIG>();

        public async Task<CICIG> GetCI(int CIId) => await _context.CICIGs.FindAsync((object)CIId);

        //public async Task<List<CIMember>> GetAllCIMember(int id) => await _context.CIMembers.Include<CIMember, CICIG>((Expression<Func<CIMember, CICIG>>)(c => c.CICIG)).Include<CIMember, Designation>((Expression<Func<CIMember, Designation>>)(a => a.Designation)).Include<CIMember, Member>((Expression<Func<CIMember, Member>>)(a => a.Member)).Where<CIMember>((Expression<Func<CIMember, bool>>)(a => a.CICIGId == id)).ToListAsync<CIMember>();
        public async Task<List<CIMember>> GetAllCIMemberById(int id)
        {        
            return await _context.CIMembers
                        .Include(cim => cim.BeneficiaryVerified)
                        .Include(cim => cim.CICIG)
                        .Where(cim => cim.CICIGId == id)
                        .ToListAsync();
        }

        //public async Task<List<Designation>> GetAllDesignation() => await this._context.Designation.OrderByDescending<Designation, int>((Expression<Func<Designation, int>>)(a => a.DesignationId)).ToListAsync<Designation>();

        public bool Exist(int Id) => _context.CIMembers.Any<CIMember>((Expression<Func<CIMember, bool>>)(e => e.CIMemberId == Id));

        public async Task Save()
        {
            int num = await this._context.SaveChangesAsync();
        }

        public void Update(CIMember communityInstituteMember)
        {
            this._context.Update<CIMember>(communityInstituteMember);
            this._context.SaveChanges();
        }

        //public async Task<CIMember> GetById(int? Id) => await _context.CIMembers.Include<CIMember, CICIG>((Expression<Func<CIMember, CICIG>>)(c => c.CICIG)).Include<CIMember, Member>((Expression<Func<CIMember, Member>>)(a => a.Member)).FirstOrDefaultAsync<CIMember>((Expression<Func<CIMember, bool>>)(m => (int?)m.CICIGMemberId == Id));
        public async Task<CIMember> GetById(int? Id)
        {
            return await _context.CIMembers
                        .Include(cim => cim.CICIG)
                        .Include(cim => cim.BeneficiaryVerified)
                        .Where(cim => cim.CIMemberId == Id)
                        .FirstOrDefaultAsync();
        }

        public async Task<CIMember> GetFromBVById(int? Id)
        {
            return await _context.CIMembers
                        .Include(cim => cim.CICIG) 
                        .Include(cim => cim.BeneficiaryVerified)
                        .Where(cim => cim.BeneficiaryVerifiedId == Id)
                        .FirstOrDefaultAsync(); 
        }

        public async Task Insert(int MemberId, int CIId, string DesignationName)
        {
            CIMember communityInstituteMember = new CIMember();
            communityInstituteMember.CICIGId = CIId;
            communityInstituteMember.BeneficiaryVerifiedId = MemberId;
            //communityInstituteMember.OnDate = DateTime.Now;
            communityInstituteMember.Designation = DesignationName;
            int num = _context.CIMembers.Count<CIMember>((Expression<Func<CIMember, bool>>)(a => a.CICIGId == CIId)) + 1;
            string ciCode = _context.CICIGs.Find((object)CIId).Code;
            communityInstituteMember.MemberCode = "(" + ciCode + ")-" + num.ToString();
            while (true)
            {
                if (_context.CIMembers.Count<CIMember>((Expression<Func<CIMember, bool>>)(a => a.MemberCode == communityInstituteMember.MemberCode)) > 0)
                {
                    ++num;
                    communityInstituteMember.MemberCode = "(" + ciCode + ")-" + num.ToString();
                }
                else
                    break;
            }
            this._context.Add<CIMember>(communityInstituteMember);
            this._context.SaveChanges();
        }

        public int IsMemberExist(string cnic) => this._context.BeneficiaryVerifieds.Where<BeneficiaryVerified>((Expression<Func<BeneficiaryVerified, bool>>)(a => a.CNIC == cnic)).Select<BeneficiaryVerified, int>((Expression<Func<BeneficiaryVerified, int>>)(a => a.BeneficiaryVerifiedId)).FirstOrDefault<int>();

        public int CountMemberInCIM(int memberId) => _context.CIMembers.Count<CIMember>((Expression<Func<CIMember, bool>>)(a => a.BeneficiaryVerifiedId == memberId));

        //public int CountMemberInLIP(int MemberId) => this._context.LIPAssetTransfer.Count<LIPAssetTransfer>((Expression<Func<LIPAssetTransfer, bool>>)(a => a.MemberId == MemberId));

        public int CountMemberWithCellInCIM(string Cellno, int CIId) => _context.CIMembers.Include<CIMember, BeneficiaryVerified>((Expression<Func<CIMember, BeneficiaryVerified>>)(a => a.BeneficiaryVerified)).Count<CIMember>((Expression<Func<CIMember, bool>>)(a => a.CICIGId == CIId));

        public async Task<BeneficiaryVerified> GetMemberByCNIC(string cnic) => this._context.BeneficiaryVerifieds.Where<BeneficiaryVerified>((Expression<Func<BeneficiaryVerified, bool>>)(a => a.CNIC == cnic)).FirstOrDefault<BeneficiaryVerified>();

        public async Task<List<District>> GetDistricts(ClaimsPrincipal user)
        {
            ApplicationUser currentuser = await this._userManager.GetUserAsync(user);
            List<District> list = this._context.Districts.Where<District>((Expression<Func<District, bool>>)(a => a.DistrictId > 1)).ToList<District>();
            if (currentuser.DistrictName == "All")
                list = list.Where<District>((Func<District, bool>)(a => a.DistrictName == currentuser.DistrictName)).ToList<District>();
            return list;
        }
    }
}
