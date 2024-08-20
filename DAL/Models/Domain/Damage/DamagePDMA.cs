using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain.MasterSetup;

namespace DAL.Models.Domain.Damage
{
    public class DamagePDMA
    {
        [Key]
        public int DamagePDMAId { get; set; }
        public string? DamageType { get; set; }
        public int Percentage { get; set; }
        public string? Attachment { get; set; }
        public int BeneficiaryPDMAId { get; set; }
        public BeneficiaryPDMA? BeneficiaryPDMA { get; set; }
        public int DamageAssessmentHTSId { get; set; }
        public DamageAssessmentHTS? DamageAssessmentHTS { set; get; }
        public int DamageAssessmentLivestockId { get; set; }
        public DamageAssessmentLivestock? DamageAssessmentLivestock { set; get; }
    }
}
