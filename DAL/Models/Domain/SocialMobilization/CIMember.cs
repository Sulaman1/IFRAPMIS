using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain.MasterSetup;
using DAL.Models.Domain.SocialMobilization.Training;

namespace DAL.Models.Domain.SocialMobilization
{
    public class CIMember
    {
        [Key]
        public int CIMemberId { get; set; }
        public string? Designation { get; set; }
        public string? MemberCode { get; set; }
        public int CICIGId { get; set; }
        public CICIG? CICIG { get; set; }

        //public int BeneficiaryVerifiedId {  get; set; }        
        //[ForeignKey("CIMemberId")]
        //[InverseProperty("CIMember")]
        public BeneficiaryVerified? BeneficiaryVerified { get; set; }

        //Navigations
        public CITrainingMember? CITrainingMember { get; set; }
    }
}
