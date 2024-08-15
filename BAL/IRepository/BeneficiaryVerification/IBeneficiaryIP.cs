using DAL.Models.Domain.MasterSetup;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.BeneficiaryVerification
{
    public interface IBeneficiaryIP
    {
        Task<List<BeneficiaryIP>> GetAll();

        Task<BeneficiaryIP> GetById(int? Id);

        Task Insert(BeneficiaryIP member, IFormFile ProfilePicture);

        Task Update(BeneficiaryIP member, IFormFile ProfilePicture);

        void Remove(BeneficiaryIP member);

        Task Save();

        bool Exist(string Cnic);

        int Count(string cnic);

        int CountCell(string cell);

        int Max();
    }
}
