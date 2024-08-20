using BAL.IRepository.Damage;
using DAL.Models.Domain.Damage;
using DAL.Models.Domain.MasterSetup;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.Damage
{

    public class DamageAssessmentHTSService : IDamageAssessmentHTS
    {
        private readonly ApplicationDbContext _context;

        public DamageAssessmentHTSService(ApplicationDbContext context) => _context = context;

        public void Remove(DamageAssessmentHTS damageAssessmentHTS) => _context.Remove(damageAssessmentHTS);

        public async Task<List<DamageAssessmentHTS>> GetAll() => await _context.DamageAssessmentHTSs.ToListAsync();

        public async Task<DamageAssessmentHTS> GetById(int? Id) => await _context.DamageAssessmentHTSs.FindAsync(Id);

        public void Insert(DamageAssessmentHTS damageAssessmentHTS)
        {
            _context.Add(damageAssessmentHTS);
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

        public bool Exist(int Id) => _context.DamageAssessmentHTSs.Any((Expression<Func<DamageAssessmentHTS, bool>>)(e => e.DamageAssessmentHTSId == Id));

        public void Update(DamageAssessmentHTS damageAssessmentHTS)
        {
            _context.Update(damageAssessmentHTS);
            _context.SaveChanges();
        }
    }
}
