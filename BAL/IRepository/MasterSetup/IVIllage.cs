using DAL.Models.Domain.MasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.MasterSetup
{
    public interface IVillage
    {
        Task<List<Village>> GetAll();

        Task<List<Tehsil>> GetAllTehsil(ClaimsPrincipal user);

        //Task<List<UnionCouncil>> GetAllUC(ClaimsPrincipal user);

        Task<Village> GetById(int? Id);

        void Insert(Village village);

        void Update(Village village);

        void Remove(Village village);

        Task Save();

        bool Exist(int Id);

        int Count(string name);
    }
}
