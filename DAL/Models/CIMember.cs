using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CIMember
    {
        [Key]
        public int CIMemberId { get; set; }
        public string? Designation {  get; set; }
        public string? MemberCode {  get; set; }
        public int CICIGId { get; set; }
        public CICIG? CICIG {  get; set; }
        
        //public int BeneficiaryVerifiedId {  get; set; }        
        //[ForeignKey("CIMemberId")]
        //[InverseProperty("CIMember")]
        public BeneficiaryVerified? BeneficiaryVerified { get; set; }        
    }
}
