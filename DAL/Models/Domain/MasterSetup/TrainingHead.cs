using DAL.Models.Domain.SocialMobilization.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class TrainingHead
    {
        [Key]
        public int TrainingHeadId { get; set; }
        [Required]
        [Display(Name = "Training Head")]
        public required string TrainingHeadName { get; set; }
        [Display(Name = "Code")]
        public required string TrainingHeadCode { get; set; }
        public required string TrainingIntervention { get; set; }

        //Collection
        public ICollection<TrainingTitle>? TrainingTitle { get; set; }
    }
}