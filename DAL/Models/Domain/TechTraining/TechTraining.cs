using DAL.Models.Domain.MasterSetup;
using DAL.Models.Domain.ResolveManyToMany;
using DAL.Models.Domain.SocialMobilization.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.TechTrainingnamespace
{
    public class TechTraining
    {
        [Key]
        public int TechTrainingId { get; set; }
        public string? TrainingName { get; set; }
        public string? TrainingCode { get; set; }
        public string? District { get; set; }
        public string? Tehsil { get; set; }
        public string? UnionCouncil { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public string? TrainingTitleName { get; set; }
        public string? TrainingHeadName { get; set; }
        public string? Gender { get; set; }
        public int? TotalMembersParticipated { get; set; }
        public int? TotalNumberMale { get; set; }
        public int? TotalNumberFemale { get; set; }

        public string? Venue { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
        public int? TotalDays { get; set; }
        public int? TotalClasses { get; set; }
        public string? Description { get; set; }
        public string? AttendanceAttachment { get; set; }
        public string? SessionPlanAttachment { get; set; }
        public string? ReportAttachment { get; set; }
        public string? PictureAttachment1 { get; set; }
        public string? PictureAttachment2 { get; set; }
        public string? PictureAttachment3 { get; set; }
        public string? PictureAttachment4 { get; set; }

        [Display(Name = "Trainer")]
        public string TechTrainer { get; set; }

        //Connections
        public int VillageId { get; set; }
        public Village? Village { get; set; }
        //public int? TrainingHeadId { get; set; }
        //public TrainingHead? TrainingHead { get; set; }
        public int? TrainingTitleId { get; set; }
        public TrainingTitle? TrainingTitle { get; set; }
        //Connection
        public int? PhaseId { get; set; }
        public Phase? Phase { get; set; }

        //Collections
        public ICollection<TechTrainingMember>? TechTrainingMemebers { get; set; }


        //public ICollection<CITrainingMember>? Members { get; set; }
        //public ICollection<CITrainingParticipation>? CITrainingParticipation { get; set; }

        //public int[]? TrainerIds { get; set; }
        //public ICollection<Trainer>? Trainer { get; set; }

        //Navigations
        public ICollection<TechTrainingTrainer>? TechTrainingTrainers { get; set; }  // Navigation property for many-to-many relationship        

    }
}
