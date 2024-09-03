using BAL.IRepository.SocialMobilization;
using DAL.Models.Domain.MasterSetup;
using DAL.Models.Domain.SocialMobilization;
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
using BAL.IRepository.Damage;
using DAL.Models.Domain.Damage;
using Microsoft.EntityFrameworkCore;
using BAL.IRepository.BeneficiaryVerification;

namespace BAL.Services.Damage
{
    public class DamageIPService : IDamageIP
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DamageIPService(
          ApplicationDbContext context,
          UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Remove(DamageIP damageIP)
        {
            _context.Remove<DamageIP>(damageIP);
            _context.SaveChanges();
        }

        public async Task<List<DamageIP>> GetAll(int id, ClaimsPrincipal user)
        {
            List<DamageIP> applicationDbContext = await _context.DamageIPs
                .Include(d => d.BeneficiaryIP)
                  .Include(s => s.DamageAssessmentHTS)
                        .Include(a => a.DamageAssessmentLivestock)
                .ToListAsync();
            return applicationDbContext;
        }
        public async Task<List<BeneficiaryIP>> GetAllBeneficiaryIPId(int beneficiaryIP)
        {
            return await _context.BeneficiaryIPs
            .Include(t => t.BeneficiaryIPId)
            .Where(d => d.BeneficiaryIPId == beneficiaryIP)
            .ToListAsync();
        }public async Task<List<DamageAssessmentHTS>> GetAllDamageAssessmentHTSId(int damageAssessmentHTS)
        {
            return await _context.DamageAssessmentHTSs
            .Include(t => t.DamageAssessmentHTSId)
            .Where(d => d.DamageAssessmentHTSId == damageAssessmentHTS)
            .ToListAsync();
        }public async Task<List<DamageAssessmentLivestock>> GetAllDamageAssessmentLivestockId(int damageAssessmentLivestock)
        {
            return await _context.DamageAssessmentLivestocks
            .Include(t => t.DamageAssessmentLivestockId)
            .Where(d => d.DamageAssessmentLivestockId == damageAssessmentLivestock)
            .ToListAsync();
        }
       
        public async Task Insert(DamageIP damageIP)
        {
            _context.Add<DamageIP>(damageIP);
            _context.SaveChanges();
        }
        public async Task<DamageIP> GetById(int? Id)
        {
            return await _context.DamageIPs
                .Where(dip => dip.BeneficiaryIPId != Id)
                .FirstOrDefaultAsync();
        }
        public async Task Save()
        {
            int num = await _context.SaveChangesAsync();
        }

        public bool Exist(int Id) => _context.DamageIPs.Any<DamageIP>((Expression<Func<DamageIP, bool>>)(e => e.DamageIPId == Id));

        public void Update(DamageIP damageIP)
        {
            _context.Update<DamageIP>(damageIP);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateDamageIP(
          DamageIP damageIP,
          int BeneficiaryIPId,
          int DamageAssessmentHTSId,
          int DamageAssessmentLivestockIPId, IFormFile Attachment)
        {
            bool flag = true;
            return flag;
        }
    }
}
