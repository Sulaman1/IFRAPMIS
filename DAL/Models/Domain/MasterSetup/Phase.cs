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
    public class Phase
    {
        [Key]
        public int PhaseId { get; set; }
        [Required]
        public required string Name { get; set; }
        
        //Collections
        public ICollection<CICIGTrainings>? CICIGTrainings { get; set; }
        public ICollection<CICIG>? CICIG { get; set; }

        //Navigations
    }
}
