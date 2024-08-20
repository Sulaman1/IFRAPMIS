using DAL.Models.Domain.Damage;
using DAL.Models.Domain.MasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.Damage
{
    public interface IDamageAssessmentLivestock
    {
        Task<List<DamageAssessmentLivestock>> GetAll();

        Task<DamageAssessmentLivestock> GetById(int? Id);

        void Insert(DamageAssessmentLivestock damageAssessmentLivestock);

        void Update(DamageAssessmentLivestock damageAssessmentLivestock);

        void Remove(DamageAssessmentLivestock damageAssessmentLivestock);

        Task Save();

        bool Exist(int Id);

        //int Count(string name);
    }
}
