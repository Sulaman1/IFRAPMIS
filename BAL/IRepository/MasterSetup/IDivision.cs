using DAL.Models.Domain.MasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.MasterSetup
{
    public interface IDivision
    {
        Task<List<Division>> GetAll();

        List<Provience> GetAllProvience();

        Task<Division> GetById(int? Id);

        void Insert(Division division);

        void Update(Division division);

        void Remove(Division division);

        Task Save();

        bool Exist(int Id);

        int Count(string name);
    }

}
