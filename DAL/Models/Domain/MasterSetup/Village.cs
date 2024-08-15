using Azure.Core.Pipeline;
using DAL.Models.Domain.SocialMobilization;
using DAL.Models.Domain.SocialMobilization.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class Village
    {
        [Key]
        public int VillageId { get; set; }
        public string? VillageName { get; set; }

        //Connections
        public int UnionCouncilId { get; set; }
        public UnionCouncil? UnionCouncils { get; set; }

        //Collections
        public ICollection<CICIG>? CICIGs { get; set; }
        public ICollection<BeneficiaryIP>? BeneficiaryIPs { get; set; }
        public ICollection<BeneficiaryPDMA>? BeneficiaryPDMAs { get; set; }
        public ICollection<BeneficiaryVerified>? BeneficiaryVerifieds { get; set; }
        public ICollection<CICIGTrainings>? CICIGTrainings { get; set; }
    }
}
