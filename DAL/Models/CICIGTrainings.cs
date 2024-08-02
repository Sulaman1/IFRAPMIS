using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CICIGTrainings
    {
        [Key]
        public int CICIGTrainingsId { get; set; }
        public string? TrainingName {  get; set; }   
        public  string? TrainingCode {  get; set; }
        public string? District { get; set; }
        public string? Tehsil {  get; set; }
        public  string? UnionCouncil {  get; set; }
        public string? Lat {  get; set; }
        public string? Long { get; set; }
        public string? TrainingTitleName {  get; set; }
        public string? TrainingHeadName {  get; set; }
        public string? Gender {  get; set; }
        public string? TotalMembersParticipated {  get; set; }
        public string? TotalNumberMale {  get; set; }
        public string? TotalNumberFemale {get; set; }
        public string? Venue {  get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime Started { get; set; }
        public DateTime  Ended { get; set; }
        public string? Attachment1 {  get; set; }
        public string? Attachment2 {  get; set; }
        public string? Attachment3 {  get; set; }

        public int VillageId { get; set; }        
        public Village? Village { get; set; }
       

        //public int CICIGId { get; set; }
        //public CICIG? CICIG { get; set; }
        //public int CITrainingparticipationId {  get; set; }
        public CITrainingParticipation? CITrainingParticipation { get; set; }
        public ICollection<CITrainingMember>? Members { get; set; }
        public TrainingHead? TrainingHead { get; set; }
        public TrainingTitle? TrainingTitle { get; set; }

    }
}
