using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.MasterSetup
{
    public interface ITehsil
    {
        Task<List<Tehsil>> GetAll();

       // Task<List<District>> GetAllDistrict();

        Task<Tehsil> GetById(int Id);

        void Insert(Tehsil tehsil);

        void Update(Tehsil tehsil);

        void Remove(Tehsil tehsil);

        Task Save();

        bool Exist(int Id);

        int Count(string name);
    }

}
