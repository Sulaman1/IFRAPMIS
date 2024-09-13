using DAL.Models.Domain.MasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IRepository.MasterSetup
{
    public interface ITrainingTitle
    {
        Task<List<TrainingTitle>> GetAll();

        List<TrainingHead> GetAllTrainingHead();

        Task<TrainingTitle> GetById(int? Id);

        void Insert(TrainingTitle trainingType);

        void Update(TrainingTitle trainingType);

        void Remove(TrainingTitle trainingType);

        Task Save();

        bool Exist(int Id);

        int Count(string name);
    }

}
