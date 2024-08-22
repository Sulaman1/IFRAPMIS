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

        //Navigations
        public CICIGTrainings? CICIGTrainings { get; set; }
        public CICIG? CICIG { get; set; }
    }
}
