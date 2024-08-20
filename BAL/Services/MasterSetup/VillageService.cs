using BAL.IRepository.MasterSetup;
using DAL.Models;
using DAL.Models.Domain.MasterSetup;
using IFRAPMIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.MasterSetup
{
    public class VillageService : IVillage
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public VillageService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        public void Remove(Village village)
        {
            this._context.Remove<Village>(village);
            this._context.SaveChanges();
        }

        //public async Task<List<Village>> GetAll() => await this._context.Villages.Include<Village, Tehsil>((Expression<Func<Village, Tehsil>>)(a => a.UnionCouncil.Tehsil)).ToListAsync<Village>();

        public async Task<List<Village>> GetAll()
        {
            return await _context.Villages.ToListAsync();
        }

        public async Task<List<Tehsil>> GetAllTehsil(ClaimsPrincipal user)
        {
            List<Tehsil> applicationDbContext = await this._context.Teshsils.ToListAsync<Tehsil>();
            ApplicationUser currentuser = await this._userManager.GetUserAsync(user);
            if (currentuser.DistrictId > 1)
                applicationDbContext = applicationDbContext.Where<Tehsil>((Func<Tehsil, bool>)(a => a.DistrictId == currentuser.DistrictId)).ToList<Tehsil>();
            List<Tehsil> allTehsil = applicationDbContext;
            applicationDbContext = (List<Tehsil>)null;
            return allTehsil;
        }

        //public async Task<List<UnionCouncil>> GetAllUC(ClaimsPrincipal user)
        //{
        //    List<UnionCouncil> allUnionCouncils = await _context.UnionCouncils.ToListAsync();
        //    ApplicationUser currentuser = await this._userManager.GetUserAsync(user);
        //    if (currentuser.DistrictId > 1)
        //    {
        //        allUnionCouncils = allUnionCouncils.Where<UnionCouncil>((Func<UnionCouncil, bool>)(a => a.Tehsils.DistrictId == currentuser.DistrictId)).ToList<UnionCouncil>();                
        //    }
        //    List<UnionCouncil> allUc = allUnionCouncils;
        //    allUnionCouncils = (List<UnionCouncil>)null;
        //    return allUc;
        //}

        public async Task<List<District>> GetAllDistrict() => await this._context.Districts.ToListAsync<District>();

        public async Task<Village> GetById(int? Id) => await this._context.Villages.FindAsync((object)Id);

        public void Insert(Village village)
        {
            this._context.Add<Village>(village);
            this._context.SaveChanges();
        }

        public async Task Save()
        {
            int num = await this._context.SaveChangesAsync();
        }

        public bool Exist(int Id)
        {
            return _context.Villages.Any(v => v.VillageId == Id);
        }

        public void Update(Village village)
        {
            this._context.Update<Village>(village);
            this._context.SaveChanges();
        }

        public int Count(string name)
        {            
            return _context.Villages.Count();
        }
    }
}

