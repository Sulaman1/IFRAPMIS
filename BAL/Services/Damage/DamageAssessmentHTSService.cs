using BAL.IRepository.Damage;
using DAL.Models.Domain.Damage;
using IFRAPMIS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.Damage
{
    public class DamageAssessmentLivestockService : IDamageAssessmentLivestock
    {
        private readonly ApplicationDbContext _context;

        public DamageAssessmentLivestockService(ApplicationDbContext context) => _context = context;

        public void Remove(DamageAssessmentLivestock damageAssessmentLivestock) => _context.Remove(damageAssessmentLivestock);

        public async Task<List<DamageAssessmentLivestock>> GetAll() => await _context.DamageAssessmentLivestocks.ToListAsync();

        public async Task<DamageAssessmentLivestock> GetById(int? Id) => await _context.DamageAssessmentLivestocks.FindAsync(Id);

        public void Insert(DamageAssessmentLivestock damageAssessmentLivestock)
        {
            _context.Add(damageAssessmentLivestock);
            _context.SaveChanges();
        }

        public async Task Save()
        {
            int num = await _context.SaveChangesAsync();
        }
        //public int Count(string name)
        //{

        //    return _context.DamageAssessmentLivestocks.Count(a => a.DamageAssessmentLivestockType.ToLower() == name.ToLower());
        //}

        public bool Exist(int Id) => _context.DamageAssessmentLivestocks.Any((Expression<Func<DamageAssessmentLivestock, bool>>)(e => e.DamageAssessmentLivestockId == Id));

        public void Update(DamageAssessmentLivestock damageAssessmentLivestock)
        {
            _context.Update(damageAssessmentLivestock);
            _context.SaveChanges();
        }
    }
}
