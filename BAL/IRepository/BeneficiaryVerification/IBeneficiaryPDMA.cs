using DAL.Models.Domain.MasterSetup;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.BeneficiaryVerification
{
    public interface IBeneficiaryPDMA
    {
        Task<List<BeneficiaryPDMA>> GetAll();

        Task<BeneficiaryPDMA> GetById(int? Id);

        Task Insert(BeneficiaryPDMA member, IFormFile ProfilePicture);

        Task Update(BeneficiaryPDMA member, IFormFile ProfilePicture);

        void Remove(BeneficiaryPDMA member);

        Task Save();

        bool Exist(string Cnic);

        int Count(string cnic);

        int CountCell(string cell);

        int Max();
    }
}
