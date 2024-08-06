using BAL.IRepository.MasterSetup;
using DAL.Models;
using IFRAPMIS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.MasterSetup
{
    public class DistrictService : IDistrict
    {
        private readonly ApplicationDbContext _context;

        public DistrictService(ApplicationDbContext context) => this._context = context;

        public void Remove(District district)
        {
            this._context.Remove<District>(district);
            this._context.SaveChanges();
        }

        //public async Task<List<District>> GetAll() => await this._context.Districts.Include<District, Division>((Expression<Func<District, Division>>)(a => a.Division)).ToListAsync<District>();

        public async Task<List<District>> GetAll()
        {
            return await _context.Districts.ToListAsync();
        }

        //public List<Division> GetAllDivision() => this._context.Division.ToList<Division>();

        //public async Task<District> GetById(int? Id) => await this._context.District.Include<District, Division>((Expression<Func<District, Division>>)(d => d.Division)).FirstOrDefaultAsync<District>((Expression<Func<District, bool>>)(m => (int?)m.DistrictId == Id));

        public async Task<District> GetById(int Id)
        {
            return await _context.Districts.FindAsync(Id);
        }

        public void Insert(District district)
        {
            this._context.Add<District>(district);
            this._context.SaveChanges();
        }

        public async Task Save()
        {
            int num = await this._context.SaveChangesAsync();
        }
        public async Task<bool> Exist(int Id)
        {
            return await _context.Districts.AnyAsync(v => v.DistrictId == Id);
        }

        public void Update(District district)
        {
            this._context.Update<District>(district);
            this._context.SaveChanges();
        }

        public int Count(string name)
        {
            return _context.Districts.Count(a => a.DistrictName.ToLower() == name.ToLower());
        }
    }
}
