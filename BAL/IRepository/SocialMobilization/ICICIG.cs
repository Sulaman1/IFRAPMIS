using DAL.Models.Domain.MasterSetup;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain.SocialMobilization;

namespace BAL.IRepository.SocialMobilization
{
    public interface ICICIG
    {
        Task<List<CICIG>> GetAll(int id, ClaimsPrincipal user);

        Task<List<Tehsil>> GetAllTehsilByDistrictId(int districtId);

        Task<List<Tehsil>> GetAllTehsilByDistrictName(string districtName);

        Task<ApplicationUser> GetCurrentUser(ClaimsPrincipal user);

        Task<List<UnionCouncil>> GetAllUCByTehsilId(int tehsilId);

        Task<List<Village>> GetAllVillageByUCId(int ucId);

        Task<List<CommunityType>> GetCommunityTypes();

        Task<List<District>> GetDistricts(ClaimsPrincipal user);

        Task<List<District>> GetAllDistrict();

        Task<List<CICIG>> GetAllSubmittedForReview(int id, ClaimsPrincipal user);

        Task<List<CICIG>> GetAllSubmittedForVerify(int id, ClaimsPrincipal user);

        Task<List<CICIG>> GetAllVerified(int id, ClaimsPrincipal user);

        Task<CICIG> GetById(int? Id);

        Task<CICIG> GetByIdSubmittedDetails(int? Id);

        Task<CICIG> GetByIdVerifiedDetails(int? Id);

        Task<bool> CISubmitForReviewRequest(int Id, string name);

        Task<bool> CIApprovalRequest(int Id, int val, string name, string description);

        Task<bool> CISubmitForApprovalRequest(int Id, int val, string name, string description);

        Task Insert(CICIG communityInstitution);

        void Update(CICIG communityInstitution);

        Task<bool> UpdateCI(
          CICIG communityInstitution,
          int DistrictId,
          IFormFile SeletionFormAttachment,
          IFormFile VillageProfileAttachment,
          IFormFile TOPAttachment);

        void Remove(CICIG communityInstitution);

        Task Save();

        bool Exist(int Id);

        int CountByDistrictName(string districtName);

        string GetDistrictCodeByName(string districtName);
    }
}
