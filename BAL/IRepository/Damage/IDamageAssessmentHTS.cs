using DAL.Models.Domain.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.Damage
{
    public interface IDamageAssessmentHTS
    {
        Task<List<DamageAssessmentHTS>> GetAll();

        Task<DamageAssessmentHTS> GetById(int? Id);

        void Insert(DamageAssessmentHTS damageAssessmentHTS);

        void Update(DamageAssessmentHTS damageAssessmentHTS);

        void Remove(DamageAssessmentHTS damageAssessmentHTS);

        Task Save();

        bool Exist(int Id);

        //int Count(string name);
    }
}
