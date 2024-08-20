using BAL.IRepository.BeneficiaryVerification;
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

namespace BAL.Services.BeneficiaryVerification
{
    public class BeneficiaryService : IBeneficiaryVerified
    {
        private readonly ApplicationDbContext _context;

        public BeneficiaryService(ApplicationDbContext context) => _context = context;

        public void Remove(BeneficiaryVerified beneficiaryVerified) => _context.Remove(beneficiaryVerified);

        public async Task<List<BeneficiaryVerified>> GetAll() => await _context.BeneficiaryVerifieds.ToListAsync();

        public async Task<BeneficiaryVerified> GetById(int? Id) => await _context.BeneficiaryVerifieds.FindAsync(Id);

        public async Task Insert(BeneficiaryVerified beneficiaryVerified, IFormFile ProfilePicture)
        {
            if (ProfilePicture != null && ProfilePicture.Length > 0L)
            {
                await using (MemoryStream memoryStream = new MemoryStream())
                {
                    await ProfilePicture.CopyToAsync(memoryStream);
                    beneficiaryVerified.ProfilePicture = memoryStream.ToArray();
                }
            }
            _context.Add(beneficiaryVerified);
            _context.SaveChanges();
        }

        public int Count(string cnic) => _context.BeneficiaryVerifieds.Count((Expression<Func<BeneficiaryVerified, bool>>)(a => a.CNIC == cnic));

        public int CountCell(string cell) => _context.BeneficiaryVerifieds.Count((Expression<Func<BeneficiaryVerified, bool>>)(a => a.Mobile == cell));

        public int Max() => _context.BeneficiaryVerifieds.Max((Expression<Func<BeneficiaryVerified, int>>)(a => a.BeneficiaryVerifiedId));

        public async Task Save()
        {
            int num = await _context.SaveChangesAsync();
        }

        public bool Exist(int Id) => _context.BeneficiaryVerifieds.Any((Expression<Func<BeneficiaryVerified, bool>>)(e => e.BeneficiaryVerifiedId == Id));

        public async Task Update(BeneficiaryVerified beneficiaryVerified, IFormFile ProfilePicture)
        {
            if (ProfilePicture != null && ProfilePicture.Length > 0L)
            {
                await using (MemoryStream memoryStream = new MemoryStream())
                {
                    await ProfilePicture.CopyToAsync(memoryStream);
                    beneficiaryVerified.ProfilePicture = memoryStream.ToArray();
                }
            }
            _context.Update(beneficiaryVerified);
            _context.SaveChanges();
        }
    }
}
