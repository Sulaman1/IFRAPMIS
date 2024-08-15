using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain.SocialMobilization;

namespace DAL.Models.Domain.MasterSetup
{
    public class BeneficiaryVerified
    {
        [Key]
        public int BeneficiaryVerifiedId { get; set; }
        public string? BeneficiaryName { get; set; }

        [Display(Name = "Beneficiary Father/Husband Name")]
        public string? BeneficiaryFather { get; set; }
        public string? Gender { get; set; }
        public string? CNIC { get; set; }
        public string? Mobile { get; set; }
        public int Age { get; set; }
        public string? MaritialStatus { get; set; }
        public bool? IsDisable { get; set; }
        public string? CNICAttachment { get; set; }
        public bool? IsRefugee { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? District { get; set; }
        public string? Tehsil { get; set; }
        public string? UnionCouncil { get; set; }

        //Connections
        public int CIMemberId { get; set; }
        //[ForeignKey("CIMemberId")]        
        public CIMember? CIMember { get; set; }
        public int? BeneficiaryIPId { get; set; }
        public BeneficiaryIP? BeneficiaryIP { get; set; }
        public int? BeneficiaryPDMAId { get; set; }
        public BeneficiaryPDMA? BeneficiaryPDMA { get; set; }
        
        //Collections
        public ICollection<DamageVerified>? DamageVerifieds { get; set; }
    }
}
