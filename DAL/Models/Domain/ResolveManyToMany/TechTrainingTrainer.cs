using DAL.Models.Domain.MasterSetup;
using DAL.Models.Domain.SocialMobilization.Training;
using DAL.Models.Domain.TechTrainingnamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.ResolveManyToMany
{
    public class TechTrainingTrainer
    {
        public int TechTrainingsId { get; set; }
        public TechTraining? TechTrainings { get; set; }

        public int TrainerId { get; set; }
        public Trainer? Trainer { get; set; }
    }
}
