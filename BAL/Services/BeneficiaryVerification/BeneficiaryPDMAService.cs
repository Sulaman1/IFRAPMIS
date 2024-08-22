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
    public class BeneficiaryPDMAService: IBeneficiaryPDMA
    {
        private readonly ApplicationDbContext _context;

        public BeneficiaryPDMAService(ApplicationDbContext context) => _context = context;

        public void Remove(BeneficiaryPDMA beneficiaryPDMA) => _context.Remove(beneficiaryPDMA);

        public async Task<List<BeneficiaryPDMA>> GetAll() => await _context.BeneficiaryPDMAs.ToListAsync();

        public async Task<BeneficiaryPDMA> GetById(int? Id) => await _context.BeneficiaryPDMAs.FindAsync(Id);

        public async Task Insert(BeneficiaryPDMA beneficiaryPDMA, IFormFile ProfilePicture)
        {
            if (ProfilePicture != null && ProfilePicture.Length > 0L)
            {
                await using (MemoryStream memoryStream = new MemoryStream())
                {
                    await ProfilePicture.CopyToAsync(memoryStream);
                    beneficiaryPDMA.ProfilePicture = memoryStream.ToArray();
                }
            }
            _context.Add(beneficiaryPDMA);
            _context.SaveChanges();
        }

        public int Count(string cnic) => _context.BeneficiaryPDMAs.Count((Expression<Func<BeneficiaryPDMA, bool>>)(a => a.CNIC == cnic));

        public int CountCell(string cell) => _context.BeneficiaryPDMAs.Count((Expression<Func<BeneficiaryPDMA, bool>>)(a => a.Mobile == cell));

        public int Max() => _context.BeneficiaryPDMAs.Max((Expression<Func<BeneficiaryPDMA, int>>)(a => a.BeneficiaryPDMAId));

        public async Task Save()
        {
            int num = await _context.SaveChangesAsync();
        }

        public bool Exist(string Cnic) => _context.BeneficiaryPDMAs.Any((Expression<Func<BeneficiaryPDMA, bool>>)(e => e.CNIC == Cnic));

        public async Task Update(BeneficiaryPDMA beneficiaryPDMA, IFormFile ProfilePicture)
        {
            if (ProfilePicture != null && ProfilePicture.Length > 0L)
            {
                await using (MemoryStream memoryStream = new MemoryStream())
                {
                    await ProfilePicture.CopyToAsync(memoryStream);
                    beneficiaryPDMA.ProfilePicture = memoryStream.ToArray();
                }
            }
            _context.Update(beneficiaryPDMA);
            _context.SaveChanges();
        }
    }
}
