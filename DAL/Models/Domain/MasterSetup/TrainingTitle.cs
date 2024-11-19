using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain.SocialMobilization.Training;
using DAL.Models.Domain.TechTrainingnamespace;

namespace DAL.Models.Domain.MasterSetup
{
    public class TrainingTitle
    {
        [Key]

        public int TitleId { get; set; }
        public required string TrainingName { get; set; }
        public required string TrainingTitleCode { get; set; }
        public required string TrainingIntervention { get; set; }

        //Connections
        public int? TrainingHeadId { get; set; }
        public TrainingHead? TrainingHead { get; set; }

        //Collections
        public ICollection<CICIGTrainings>? CICIGTrainings { get; set; }
        public ICollection<TechTraining>? TechTrainings { get; set; }

    }
}
