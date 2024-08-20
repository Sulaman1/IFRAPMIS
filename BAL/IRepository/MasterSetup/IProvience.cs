using DAL.Models.Domain.MasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.MasterSetup
{
    public interface IProvience
    {
        Task<List<Provience>> GetAll();

        Task<Provience> GetById(int? Id);

        void Insert(Provience provience);

        void Update(Provience provience);

        void Remove(Provience provience);

        Task Save();

        bool Exist(int Id);
    }
}
