using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CICIG
    {
        [Key]
        public int CICIGId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Code { get; set; }
        public string? Gender { get; set; }
        public string? Lat { get; set; }
        public string?  Long { get; set; }
        public string? EntryBy { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int HouseHoldNumber { get; set; }
        public string? VerifiedBy { get; set; }
        public DateTime VerificationDate { get; set; }
        public string? VerificationComments { get; set; }
        public bool IsVerified { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime ApprovalDate { get; set; }
        public bool IsApproved { get; set; }
        public string? ApprovalComments { get; set; }
        public string? Venue { get; set; }
        public string? Attachement1 { get; set; }
        public string? Attachement2 { get; set; }
        public string? Attachement3 { get; set; }
        public string? District { get; set; }
        public string? Tehsil { get; set; }
        public string? UnionCouncil { get; set; }
        public int VillageId { get; set; }
        public Village? Village { get; set; }

        //public ICollection<CICIGTrainings>? CICIGTrainings { get; set; }
        public ICollection<CIMember>? CICIGMember { get; set; }

        //public int CITrainingParticipationId {  get; set; }
        public CITrainingParticipation? CITrainingParticipation { get; set; }        
    }
}
