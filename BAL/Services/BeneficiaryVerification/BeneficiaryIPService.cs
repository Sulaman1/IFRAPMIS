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
    public class BeneficiaryIPService: IBeneficiaryIP
    {
        private readonly ApplicationDbContext _context;

        public BeneficiaryIPService(ApplicationDbContext context) => _context = context;

        public void Remove(BeneficiaryIP beneficiaryIP) => _context.Remove(beneficiaryIP);

        public async Task<List<BeneficiaryIP>> GetAll() => await _context.BeneficiaryIPs.ToListAsync();

        public async Task<BeneficiaryIP> GetById(int? Id) => await _context.BeneficiaryIPs.FindAsync(Id);

        public async Task Insert(BeneficiaryIP beneficiaryIP, IFormFile ProfilePicture)
        {
            if (ProfilePicture != null && ProfilePicture.Length > 0L)
            {
                await using (MemoryStream memoryStream = new MemoryStream())
                {
                    await ProfilePicture.CopyToAsync(memoryStream);
                    beneficiaryIP.ProfilePicture = memoryStream.ToArray();
                }
            }
            _context.Add(beneficiaryIP);
            _context.SaveChanges();
        }

        public int Count(string cnic) => _context.BeneficiaryIPs.Count((Expression<Func<BeneficiaryIP, bool>>)(a => a.CNIC == cnic));

        public int CountCell(string cell) => _context.BeneficiaryIPs.Count((Expression<Func<BeneficiaryIP, bool>>)(a => a.Mobile == cell));

        public int Max() => _context.BeneficiaryIPs.Max((Expression<Func<BeneficiaryIP, int>>)(a => a.BeneficiaryIPId));

        public async Task Save()
        {
            int num = await _context.SaveChangesAsync();
        }

        public bool Exist(string Cnic) => _context.BeneficiaryIPs.Any((Expression<Func<BeneficiaryIP, bool>>)(e => e.CNIC == Cnic));

        public async Task Update(BeneficiaryIP beneficiaryIP, IFormFile ProfilePicture)
        {
            if (ProfilePicture != null && ProfilePicture.Length > 0L)
            {
                await using (MemoryStream memoryStream = new MemoryStream())
                {
                    await ProfilePicture.CopyToAsync(memoryStream);
                    beneficiaryIP.ProfilePicture = memoryStream.ToArray();
                }
            }
            _context.Update(beneficiaryIP);
            _context.SaveChanges();
        }
    }
}
