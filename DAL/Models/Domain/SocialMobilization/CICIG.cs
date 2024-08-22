using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain.MasterSetup;
using DAL.Models.Domain.SocialMobilization.Training;

namespace DAL.Models.Domain.SocialMobilization
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
        public string? Long { get; set; }
        public string? EntryBy { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int HouseHoldNumber { get; set; }
        public int HouseHoldParticipated { get; set; }

        public bool? IsRejected { get; set; }
        public string? RejectedComments { get; set; }
        public bool? IsReviewed { get; set; }
        public string? ReviewedBy { get; set; }
        public DateTime? ReviewedDate { get; set; }
        public bool? IsSubmittedForReview { get; set; }
        public string? SubmittedForReviewBy { get; set; }
        public DateTime? SubmittedForReviewDate { get; set; }

        public string? VerifiedBy { get; set; }
        public DateTime VerificationDate { get; set; }
        public string? VerificationComments { get; set; }
        public bool IsVerified { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime ApprovalDate { get; set; }
        public bool IsApproved { get; set; }
        public string? ApprovalComments { get; set; }
        public string? Venue { get; set; }
        public string? SelectionFormAttachment { get; set; }
        public string? VillageProfileAttachment { get; set; }
        public string? TOPAttachment { get; set; }
        public string? District { get; set; }
        public string? Tehsil { get; set; }
        public string? UnionCouncil { get; set; }

        //Connections
        public int VillageId { get; set; }
        public Village? Village { get; set; }
        public int? PhaseId { get; set; }
        public Phase? Phase { get; set; }
        public int? CommunityTypeId { get; set; }
        public CommunityType? CommunityType { get; set; }

        //Collections
        public ICollection<CIMember>? CICIGMember { get; set; }
        
        //Navigations
        public CITrainingParticipation? CITrainingParticipation { get; set; }

        //public ICollection<CICIGTrainings>? CICIGTrainings { get; set; }
        //public int CITrainingParticipationId {  get; set; }
    }
}
