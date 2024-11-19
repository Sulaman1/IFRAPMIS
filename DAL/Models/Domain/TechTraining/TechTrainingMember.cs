using DAL.Models.Domain.SocialMobilization.Training;
using DAL.Models.Domain.SocialMobilization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Domain.MasterSetup;

namespace DAL.Models.Domain.TechTrainingnamespace
{
    public class TechTrainingMember
    {
        [Key]
        public int TechTrainingMemberId { get; set; }       

        [Display(Name = "Training Code")]
        public string? BeneficiaryTrainingCode { get; set; }

        public int Age { get; set; }

        [Display(Name = "Education Doc")]
        public string? EducationDocAttachment { get; set; }

        [Display(Name = "Certificate")]
        public string? CertificateAttachment { get; set; }

        [Display(Name = "CNIC")]
        public string? CNICAttachment { get; set; }

        [Display(Name = "Admission Form")]
        public string? AdmissionFormAttachment { get; set; }

        public string PWD { get; set; }

        [Display(Name = "Self Employed")]
        public string SelfEmployed { get; set; }

        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }
            = "";

        [Display(Name = "Preferred Skill 1")]
        public string PreferredSkill1 { get; set; }

        [Display(Name = "Preferred Skill 2")]
        public string? PreferredSkill2 { get; set; }

        [Display(Name = "Preferred Skill 3")]
        public string? PreferredSkill3 { get; set; }

        [Display(Name = "Preferred Skill 4")]
        public string? PreferredSkill4 { get; set; }

        [Display(Name = "Identified By")]
        public string IdentifiedBy { get; set; }

        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; } = DateTime.Today.Date;

        //Connections
        [Display(Name = "Training")]
        [ForeignKey("TechTraining")]
        public int TechTrainingId { get; set; }
        public TechTraining? TechTraining { get; set; }

        [Display(Name = "Beneficiary")]
        [ForeignKey("BeneficiaryVerified")]
        public int BeneficiaryVerifiedId { get; set; }        
        public BeneficiaryVerified? BeneficiaryVerified { get; set; }              
    }
}
