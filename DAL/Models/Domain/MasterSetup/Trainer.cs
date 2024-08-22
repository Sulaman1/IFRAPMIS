using DAL.Models.Domain.ResolveManyToMany;
using DAL.Models.Domain.SocialMobilization.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }
        [Display(Name = "Trainer")]
        public string? TrainerName { get; set; }
        [Display(Name = "Father Name")]
        public string? FatherName { get; set; }
        public string? CNIC { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; } = "";
        public string Address { get; set; } = "";
        public string Designation { get; set; } = "";
        public bool IsActive { get; set; } = true;

        //Connections
        [Display(Name = "Section")]
        public int SectionId { get; set; }
        public Section? Section { get; set; }
        public int? DistrictId { get; set; }
        public District? District { get; set; }


        //Navigations 
        public ICollection<CICIGTrainingTrainer>? CICIGTrainingTrainers { get; set; }  // Navigation property for many-to-many relationship

        //public int? CICIGTrainingsId { get; set; }
        //public CICIGTrainings? CICIGTrainings { get; set; }
    }
}

