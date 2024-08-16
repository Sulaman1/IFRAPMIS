using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain.MasterSetup;

namespace DAL.Models.Domain.SocialMobilization.Training
{
    public class CICIGTrainings
    {
        [Key]
        public int CICIGTrainingsId { get; set; }
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
        public string? Attachment1 { get; set; }
        public string? Attachment2 { get; set; }
        public string? Attachment3 { get; set; }


        //Connections
        public int VillageId { get; set; }
        public Village? Village { get; set; }       
        public int? TrainingHeadId { get; set; }
        public TrainingHead? TrainingHead { get; set; }
        public int? TrainingTitleId { get; set; }
        public TrainingTitle? TrainingTitle { get; set; }

        //Collections
        public ICollection<CITrainingMember>? Members { get; set; }      
        public ICollection<CITrainingParticipation>? CITrainingParticipation { get; set; }

        //Navigations
        //public CITrainingMember? CITrainingMember { get; set; }
    }
}
