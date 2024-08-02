using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DamageIP
    {
        [Key]
        public int DamageIPId { get; set; }
        public string? DamageType { get; set; }
        public int Percentage { get; set; }
        public string? Attachment { get; set; }        
        public int BeneficiaryIPId { get; set; }
        public BeneficiaryIP? BeneficiaryIP { get; set; }
        public int DamageAssessmentHTSId { get; set; }
        public DamageAssessmentHTS? DamageAssessmentHTS {  set; get; }
        public int DamageAssessmentLivestockId { get; set; }
        public DamageAssessmentLivestock? DamageAssessmentLivestock { set; get; }


    }
}
