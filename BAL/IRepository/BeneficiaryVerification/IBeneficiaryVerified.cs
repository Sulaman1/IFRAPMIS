using DAL.Models.Domain.MasterSetup;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.BeneficiaryVerification
{
    public interface IBeneficiaryVerified
    {
        Task<List<BeneficiaryVerified>> GetAll();

        Task<BeneficiaryVerified> GetById(int? Id);

        Task Insert(BeneficiaryVerified member, IFormFile ProfilePicture);

        Task Update(BeneficiaryVerified member, IFormFile ProfilePicture);

        void Remove(BeneficiaryVerified member);

        Task Save();        

        int Count(string cnic);

        int CountCell(string cell);

        int Max();
    }
}
