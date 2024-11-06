using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class BeneficiaryListViewModel
    {
        public int BeneficiaryIPId { get; set; }
        public int BeneficiaryPDMAId { get; set; }
        public string BeneficiaryNameIP { get; set; }
        public string BeneficiaryNamePDMA { get; set; }
        public string CNIC { get; set; }


        /////////////////////////////////////
                          
        public string? BeneficiaryFatherIP { get; set; }
        public string? BeneficiaryFatherPDMA { get; set; }
        public string? GenderIP { get; set; }        
        public string? GenderPDMA { get; set; }        
        public string? MobileIP { get; set; }
        public string? MobilePDMA { get; set; }
        public int AgeIP { get; set; }
        public int AgePDMA { get; set; }
        public string? MaritialStatusIP { get; set; }
        public string? MaritialStatusPDMA { get; set; }
        public bool IsDisableIP { get; set; }
        public bool IsDisablePDMA { get; set; }
        public string? CNICAttachmentIP { get; set; }
        public string? CNICAttachmentPDMA { get; set; }
        public bool IsRefugeeIP { get; set; }
        public bool IsRefugeePDMA { get; set; }
        public byte[]? ProfilePictureIP { get; set; }
        public byte[]? ProfilePicturePDMA { get; set; }
        public string? DistrictIP { get; set; }
        public string? DistrictPDMA { get; set; }
        public string? TehsilIP { get; set; }
        public string? TehsilPDMA { get; set; }
        public string? UnionCouncilIP { get; set; }
        public string? UnionCouncilPDMA { get; set; }

        public DateTime? SurveyDateIP { get; set; }
        public DateTime? SurveyDatePDMA { get; set; }
        public string? NextOfKinIP { get; set; }
        public string? NextOfKinPDMA { get; set; }
        public string? NextOfKinCNICIP { get; set; }
        public string? NextOfKinCNICPDMA { get; set; }
        public bool IsVerifiedPDMA { get; set; }
        public bool IsVerifiedIP { get; set; }
        public bool IsRejectedPDMA { get; set; } = false;
        public bool IsOnHoldPDMA { get; set; } = false;
        public bool IsRejectedIP { get; set; } = false;
        public bool IsOnHoldIP { get; set; } = false;
    }
}
