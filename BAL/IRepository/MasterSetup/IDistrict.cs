using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.MasterSetup
{
    public interface IDistrict
    {
        Task<List<District>> GetAll();

        //List<Division> GetAllDivision();

        Task<District> GetById(int Id);

        void Insert(District district);

        void Update(District district);

        void Remove(District district);

        Task Save();

        Task<bool> Exist(int Id);

        int Count(string name);
    }
}
