using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class SurveyTeam
    {
        [Key]
        public int SurveyTeamId { get; set; }
        public string? TeamLeadName { get; set; }
        public string? Member1Name { get; set; }
        public string? Member2Name { get; set; }
        public string? Member3Name { get; set; }
        public string? ArmyMemberName { get; set; }
        public string? NDMAMemberName { get; set; }
        public string? CollectedByOrganization { get; set; }

        //Connections        
        public ICollection<BeneficiaryPDMA>? BeneficiaryPDMA { get; set; }
        public ICollection<BeneficiaryIP>? BeneficiaryIP { get; set; }
        public ICollection<BeneficiaryVerified>? BeneficiaryVerified { get; set; }
    }
}
