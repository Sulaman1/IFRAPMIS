using DAL.Models.Domain.MasterSetup;
using DAL.Models;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain.SocialMobilization;
using Microsoft.EntityFrameworkCore;
using BAL.IRepository.SocialMobilization;

namespace BAL.Services.SocialMobilization
{
    public class CICIGService: ICICIG
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CICIGService(
          ApplicationDbContext context,
          UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Remove(CICIG communityInstitution)
        {
            _context.Remove<CICIG>(communityInstitution);
            _context.SaveChanges();
        }

        public async Task<List<CICIG>> GetAll(int id, ClaimsPrincipal user)
        {
            //List<CICIG> applicationDbContext = await _context.CICIGs.Include<CICIG, District>((Expression<Func<CICIG, District>>)(c => c.Village.UnionCouncils.Tehsil.District)).Where<CICIG>((Expression<Func<CICIG, bool>>)(a => a.CommunityTypeId == id && a.IsSubmittedForReview == false)).ToListAsync<CICIG>();
            //List<CICIG> applicationDbContext = await _context.CICIGs.Include(c => c.Village).ToListAsync();
            List<CICIG> applicationDbContext = await _context.CICIGs
                .Include(c => c.Village)
                    .ThenInclude(v => v.UnionCouncils)
                        .ThenInclude(uc => uc.Tehsil)
                            .ThenInclude(t => t.District)
                .ToListAsync();



            //ApplicationUser currentuser = await _userManager.GetUserAsync(user);
            //if (currentuser.DistrictId > 1)
            //applicationDbContext = applicationDbContext.Where<CICIG>((Func<CICIG, bool>)(a => a.DistrictId == currentuser.DistrictId)).ToList<CICIG>();
            //List<CICIG> all = applicationDbContext;
            //applicationDbContext = (List<CICIG>)null;
            return applicationDbContext;
        }

        //public async Task<List<Tehsil>> GetAllTehsil(int districtId) => await _context.Tehsil.Where<Tehsil>((Expression<Func<Tehsil, bool>>)(a => a.DistrictId == districtId)).ToListAsync<Tehsil>();
        public async Task<List<Tehsil>> GetAllTehsilByDistrictId(int districtId)
        {
            return await _context.Tehsils
            .Include(t => t.District) // Eagerly load the related District entity
            .Where(d => d.DistrictId == districtId)
            .ToListAsync();           
        }
        public async Task<List<Tehsil>> GetAllTehsilName(string districtName) => await _context.Tehsils.Include<Tehsil, District>((Expression<Func<Tehsil, District>>)(a => a.District)).Where<Tehsil>((Expression<Func<Tehsil, bool>>)(a => a.District.DistrictName == districtName)).ToListAsync<Tehsil>();
        public async Task<List<Tehsil>> GetAllTehsilByDistrictName(string districtName)
        {
            return await _context.Tehsils
            .Include(t => t.District) // Eagerly load the related District entity
            .Where(d => d.District.DistrictName == districtName)
            .ToListAsync();
        }
        public async Task<List<District>> GetDistricts(ClaimsPrincipal user)
        {
            //List<District> districts = _context.District.Where<District>((Expression<Func<District, bool>>)(a => a.DistrictId > 1)).ToList<District>();
            List<District> districts = await _context.Districts.ToListAsync();
            ApplicationUser currentUser = await _userManager.GetUserAsync(user);
            //if (currentUser.DistrictId > 1)
            //    districts = districts.Where<District>((Func<District, bool>)(a => a.DistrictId == currentUser.DistrictId)).ToList<District>();
            //List<District> districts1 = districts;
            //districts = (List<District>)null;
            return districts;
        }

        public async Task<ApplicationUser> GetCurrentUser(ClaimsPrincipal user) => await _userManager.GetUserAsync(user);

        public async Task<List<UnionCouncil>> GetAllUC(int tehsilId) => await _context.UnionCouncils.Where<UnionCouncil>((Expression<Func<UnionCouncil, bool>>)(a => a.TehsilId == tehsilId)).ToListAsync<UnionCouncil>();
        public async Task<List<UnionCouncil>> GetAllUCByTehsilId(int tehsilId)
        {
            return await _context.UnionCouncils
                .Where(uc => uc.TehsilId == tehsilId)
                .ToListAsync();
        }

        //public async Task<List<Village>> GetAllVillage(int ucId) => await _context.Village.Where<Village>((Expression<Func<Village, bool>>)(a => a.UnionCouncilId == ucId)).ToListAsync<Village>();
        public async Task<List<Village>> GetAllVillageByUCId(int ucId)
        {
            return await _context.Villages
                .Where(v => v.UnionCouncilId == ucId)
                .ToListAsync();
        }

        public async Task<List<District>> GetAllDistrict() => await _context.Districts.ToListAsync<District>();

        public async Task<List<CommunityType>> GetCommunityTypes()
        {
            return await _context.CommunityTypes.ToListAsync();  
            //return await _context.CommunityTypes.Where<CommunityType>((Expression<Func<CommunityType, bool>>)(a => a.CommunityTypeId < 3)).ToListAsync<CommunityType>();
        }

        public async Task<List<CICIG>> GetAllSubmittedForReview(
          int id,
          ClaimsPrincipal user)
        {
            List<CICIG> applicationDbContext = await _context.CICIGs.Include<CICIG, District>((Expression<Func<CICIG, District>>)(c => c.Village.UnionCouncils.Tehsil.District)).Where<CICIG>((Expression<Func<CICIG, bool>>)(a => a.CommunityTypeId == id && a.IsSubmittedForReview == true && a.IsReviewed == false)).ToListAsync<CICIG>();
            ApplicationUser currentuser = await _userManager.GetUserAsync(user);
            if (currentuser.DistrictName == "All")
                applicationDbContext = applicationDbContext.Where<CICIG>((Func<CICIG, bool>)(a => a.Village.UnionCouncils.Tehsil.District.DistrictName == currentuser.DistrictName)).ToList<CICIG>();
            List<CICIG> submittedForReview = applicationDbContext;
            applicationDbContext = (List<CICIG>)null;
            return submittedForReview;
        }

        public async Task<List<CICIG>> GetAllSubmittedForVerify(
          int id,
          ClaimsPrincipal user)
        {
            List<CICIG> applicationDbContext = await _context.CICIGs.Include<CICIG, District>((Expression<Func<CICIG, District>>)(c => c.Village.UnionCouncils.Tehsil.District)).Where<CICIG>((Expression<Func<CICIG, bool>>)(a => a.CommunityTypeId == id && a.IsReviewed == true && a.IsVerified == false)).ToListAsync<CICIG>();
            ApplicationUser currentuser = await _userManager.GetUserAsync(user);
            if (currentuser.DistrictName == "All")
                applicationDbContext = applicationDbContext.Where<CICIG>((Func<CICIG, bool>)(a => a.Village.UnionCouncils.Tehsil.District.DistrictName == currentuser.DistrictName)).ToList<CICIG>();
            List<CICIG> submittedForVerify = applicationDbContext;
            applicationDbContext = (List<CICIG>)null;
            return submittedForVerify;
        }

        public async Task<List<CICIG>> GetAllVerified(int id, ClaimsPrincipal user)
        {
            //List<CICIG> applicationDbContext = await _context.CICIGs.Include<CICIG, District>((Expression<Func<CICIG, District>>)(c => c.Village.UnionCouncil.Tehsil.District)).Where<CICIG>((Expression<Func<CICIG, bool>>)(a => a.CommunityTypeId == id && a.IsVerified == true)).ToListAsync<CICIG>();
            List<CICIG> applicationDbContext = await _context.CICIGs
                                                    .Where(cicig => cicig.IsVerified)
                                                    .ToListAsync();
            //ApplicationUser currentuser = await _userManager.GetUserAsync(user);
            //if (currentuser.DistrictId > 1)
            //    applicationDbContext = applicationDbContext.Where<CICIG>((Func<CICIG, bool>)(a => a.DistrictId == currentuser.DistrictId)).ToList<CICIG>();
            //List<CICIG> allVerified = applicationDbContext;
            //applicationDbContext = (List<CICIG>)null;
            return applicationDbContext;
        }

        //public async Task<CICIG> GetById(int? Id) => await _context.CICIGs.Include<CICIG, District>((Expression<Func<CICIG, District>>)(c => c.Village.UnionCouncils.Tehsil.District)).FirstOrDefaultAsync<CICIG>((Expression<Func<CICIG, bool>>)(m => (int?)m.CICIGId == Id));

        public async Task<CICIG> GetById(int? Id)
        {
            return await _context.CICIGs
                .Where(cicig => cicig.CICIGId != Id)
                .FirstOrDefaultAsync();
        }

        public async Task<CICIG> GetByIdSubmittedDetails(int? Id) => await _context.CICIGs.Include<CICIG, District>((Expression<Func<CICIG, District>>)(c => c.Village.UnionCouncils.Tehsil.District)).Where<CICIG>((Expression<Func<CICIG, bool>>)(a => a.IsSubmittedForReview == true && a.IsVerified == false)).FirstOrDefaultAsync<CICIG>((Expression<Func<CICIG, bool>>)(m => (int?)m.CICIGId == Id));

        //public async Task<CICIG> GetByIdVerifiedDetails(int? Id) => await _context.CICIGs.Include<CICIG, District>((Expression<Func<CICIG, District>>)(c => c.Village.UnionCouncil.Tehsil.District)).Where<CICIG>((Expression<Func<CICIG, bool>>)(a => a.IsReviewed == true && a.IsSubmittedForReview == true)).FirstOrDefaultAsync<CICIG>((Expression<Func<CICIG, bool>>)(m => (int?)m.CICIGId == Id));

        public async Task<CICIG> GetByIdVerifiedDetails(int? Id)
        {
            return await _context.CICIGs
                .Where(cicig => cicig.IsVerified == true && cicig.CICIGId != Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CISubmitForReviewRequest(int Id, string name)
        {
            CICIG async = await _context.CICIGs.FindAsync((object)Id);
            if (async == null)
                return false;
            async.IsSubmittedForReview = true;
            async.SubmittedForReviewDate = new DateTime?(DateTime.Now);
            async.SubmittedForReviewBy = name;
            Update(async);
            Save();
            return true;
        }

        public async Task<bool> CIApprovalRequest(int Id, int val, string name, string description)
        {
            CICIG Cicig = await _context.CICIGs.FindAsync(Id);
            if (Cicig == null)
                return false;
            if (val == 0)
            {
                Cicig.IsVerified = false;
                //Cicig.IsReviewed = false;
                //Cicig.IsRejected = true;
                //Cicig.RejectedComments = description;
            }
            else
            {
                Cicig.IsVerified = true;
                Cicig.VerificationDate = DateTime.Today.Date;
                Cicig.VerifiedBy = name;
            }
            Update(Cicig);
            await Save();
            return true;
        }

        public async Task<bool> CISubmitForApprovalRequest(
          int Id,
          int val,
          string name,
          string description)
        {
            CICIG Cicig = await _context.CICIGs.FindAsync(Id);
            if (Cicig == null)
                return false;
            if (val == 0)
            {
                //Cicig.IsSubmittedForReview = false;
                //Cicig.IsRejected = true;
                //Cicig.RejectedComments = description;
            }
            else
            {
                //Cicig.IsReviewed = true;
                //Cicig.ReviewedOn = new DateTime?(DateTime.Today.Date);
                //Cicig.ReviewedBy = name;
                //Cicig.IsRejected = false;
            }
            Update(Cicig);
            await Save();
            return true;
        }

        public async Task Insert(CICIG communityInstitution)
        {
            int num = CountByDistrictName(communityInstitution.District) + 1;

            string districtCodeById = GetDistrictCodeByName(communityInstitution.District);
            string str1 = num.ToString("D3");
            communityInstitution.Code = districtCodeById + "-" + str1;
            while (true)
            {
                if (_context.CICIGs.Count<CICIG>((Expression<Func<CICIG, bool>>)(a => a.Code == communityInstitution.Code)) > 0)
                {
                    string str2 = (++num).ToString("D3");
                    communityInstitution.Code = districtCodeById + "-" + str2;
                }
                else
                    break;
            }
            //communityInstitution.DistrictId = DistrictId;
            communityInstitution.DateOfCreation = DateTime.Today.Date;
            //communityInstitution.District = _context.District.Find((object)DistrictId).Name;
            _context.Add<CICIG>(communityInstitution);
            _context.SaveChanges();
        }

        //public int Count(int districtId) => _context.CICIGs.Count<CICIG>((Expression<Func<CICIG, bool>>)(a => a.DistrictId == districtId));
        public int CountByDistrictName(string districtName)
        {
            return _context.CICIGs
                .Count(cicig => cicig.District == districtName);
                
        }
        public string GetDistrictCodeByName(string districtName)
        {
            var district = _context.Districts.FirstOrDefault(d => d.DistrictName == districtName);
            if (district == null)
            {
                // Handle the case where the district is not found
                throw new Exception("District not found.");
            }
            return district.Code;            
        }

        public async Task Save()
        {
            int num = await _context.SaveChangesAsync();
        }

        public bool Exist(int Id) => _context.CICIGs.Any<CICIG>((Expression<Func<CICIG, bool>>)(e => e.CICIGId == Id));

        public void Update(CICIG communityInstitution)
        {
            _context.Update<CICIG>(communityInstitution);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateCI(
          CICIG communityInstitution,
          int DistrictId,
          IFormFile SeletionFormAttachment,
          IFormFile VillageProfileAttachment,
          IFormFile TOPAttachment)
        {
            bool flag = true;
            return flag;
        }
    }
}