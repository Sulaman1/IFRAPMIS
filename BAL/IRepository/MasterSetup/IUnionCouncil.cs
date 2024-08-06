using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.MasterSetup
{
    public interface IUnionCouncil
    {
        Task<List<UnionCouncil>> GetAll();

       // Task<List<Tehsil>> GetAllTehsil();

       // Task<List<District>> GetAllDistrict();

        Task<UnionCouncil> GetById(int? Id);

        void Insert(UnionCouncil unionCouncil);

        void Update(UnionCouncil unionCouncil);

        void Remove(UnionCouncil unionCouncil);

        Task Save();

        bool Exist(int Id);

        int Count(string name);
    }
    
}
