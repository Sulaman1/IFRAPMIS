using DAL.Models.Domain.MasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.MasterSetup
{
    public interface ITrainingHead
    {
        Task<List<TrainingHead>> GetAll();

        Task<TrainingHead> GetById(int? Id);

        void Insert(TrainingHead trainingHead);

        void Update(TrainingHead trainingHead);

        void Remove(TrainingHead trainingHead);

        Task Save();

        bool Exist(int Id);

        int Count(string name);
    }
}
