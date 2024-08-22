using DAL.Models.Domain.MasterSetup;
using DAL.Models.Domain.SocialMobilization.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.ResolveManyToMany
{
    public class CICIGTrainingTrainer
    {
        public int CICIGTrainingsId { get; set; }
        public CICIGTrainings? CICIGTrainings { get; set; }

        public int TrainerId { get; set; }
        public Trainer? Trainer { get; set; }
    }
}
