using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
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
        public int Age { get; set; }
        public string? MaritialStatus { get; set; }
        public string? DisabilityType { get; set; }
        public string? CNICAttachment { get; set; }
        public string? District { get; set; }
        public string? Tehsil { get; set; }
        public string? UnionCouncil { get; set; }

        public ICollection<DamagePDMA>? DamagePDMAs { get; set; }
    }
}
