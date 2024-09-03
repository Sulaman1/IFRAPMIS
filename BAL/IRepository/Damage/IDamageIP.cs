using DAL.Models.Domain.MasterSetup;
using DAL.Models.Domain.SocialMobilization;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain.Damage;

namespace BAL.IRepository.Damage
{
    public interface IDamageIP
    {
        Task<List<DamageIP>> GetAll(int id, ClaimsPrincipal user);

        Task<List<BeneficiaryIP>> GetAllBeneficiaryIPId(int beneficiaryIP);

        Task<List<DamageAssessmentHTS>> GetAllDamageAssessmentHTSId(int damageAssessmentHTS);

        Task<List<DamageAssessmentLivestock>> GetAllDamageAssessmentLivestockId(int damageAssessmentLivestock);
        Task Insert(DamageIP damageIP);
        Task<DamageIP> GetById(int? Id);
        void Update(DamageIP damageIP);

        Task<bool> UpdateDamageIP(
          DamageIP damageIP,
          int BeneficiaryIPId,
          int DamageAssessmentHTSId,
          int DamageAssessmentLivestockIPId,
          IFormFile Attachment);

        void Remove(DamageIP damageIP);

        Task Save();

        bool Exist(int Id);
    }
}
