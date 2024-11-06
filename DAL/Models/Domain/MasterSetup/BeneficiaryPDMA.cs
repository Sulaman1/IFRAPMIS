﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain.Damage;

namespace DAL.Models.Domain.MasterSetup
{
    public class BeneficiaryPDMA
    {
        [Key]
        public int BeneficiaryPDMAId { get; set; }
        public string? BeneficiaryName { get; set; }

        [Display(Name = "Beneficiary Father/Husband Name")]
        public string? BeneficiaryFather { get; set; }
        public string? Gender { get; set; }
        public string? CNIC { get; set; }
        public string? Mobile { get; set; }
        public int? Age { get; set; }
        public string? MaritialStatus { get; set; }
        public bool IsDisable { get; set; }
        public string? CNICAttachment { get; set; }
        public bool IsRefugee { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? District { get; set; }
        public string? Tehsil { get; set; }
        public string? UnionCouncil { get; set; }
        public DateTime? SurveyDate { get; set; }
        public string? NextOfKin { get; set; }
        public string? NextOfKinCNIC { get; set; }
        public bool IsVerified { get; set; } = false; 
        public bool IsRejected { get; set; } = false;
        public bool IsOnHold { get; set; } = false;
        public string? Comments { get; set; }

        //Connection
        public int? SurveyTeamPDMAId { get; set; }
        public SurveyTeamPDMA? SurveyTeamPDMA { get; set; }

        //Collections
        public ICollection<DamagePDMA>? DamagePDMAs { get; set; }
        
        //Navigations
        public BeneficiaryVerified? BeneficiaryVerified { get; set; }
    }
}
