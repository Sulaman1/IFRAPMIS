using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.Damage
{
    public class DamageAssessmentLivestock
    {
        [Key]
        public int DamageAssessmentLivestockId { get; set; }
        public string? DamageAssessmentLivestockType { get; set; }
        public ICollection<DamageIP>? DamageIPs { get; set; }
        public ICollection<DamagePDMA>? DamagePDMAs { get; set; }
        public ICollection<DamageVerified>? DamageVerifieds { get; set; }
    }
}
