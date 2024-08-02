using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Village
    {
        [Key]
        public int VillageId { get; set; }
        public string? VillageName { get; set; }
        public int UnionCouncilId { get; set; } 
        public UnionCouncil? UnionCouncils { get; set; } 
        public ICollection<CICIG>? CICIGs { get; set; }
        public ICollection<BeneficiaryIP>? BeneficiaryIPs { get; set; }
        public ICollection<BeneficiaryPDMA>? BeneficiaryPDMAs { get; set; }
        public ICollection<BeneficiaryVerified>? BeneficiaryVerifieds { get; set; }
        public ICollection<CICIGTrainings>? CICIGTrainings { get; set; }

    }
}
