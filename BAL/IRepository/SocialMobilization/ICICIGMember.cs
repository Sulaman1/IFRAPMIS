using DAL.Models.Domain.MasterSetup;
using DAL.Models.Domain.SocialMobilization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.SocialMobilization
{
    public interface ICICIGMember
    {
        Task<List<CIMember>> GetAll();

        List<CICIG> GetAllCI();

        Task<List<District>> GetDistricts(ClaimsPrincipal user);

        Task<CICIG> GetCI(int CIId);

        Task<List<CIMember>> GetAllCIMemberById(int Id);
        Task<CIMember> GetById(int? Id);
        Task<CIMember> GetFromBVById(int? Id);

        Task<BeneficiaryVerified> GetMemberByCNIC(string cnic);

        //Task<List<Designation>> GetAllDesignation();

        Task Insert(int memberId, int CIId, string DesignationName);

        void Update(CIMember communityInstituteMember);

        void Remove(CIMember communityInstituteMember);

        Task Save();

        bool Exist(int Id);

        int IsMemberExist(string cnic);

        int CountMemberInCIM(int memberId);

        //int CountMemberInLIP(int memberId);

        int CountMemberWithCellInCIM(string Cellno, int CIId);
    }
}
