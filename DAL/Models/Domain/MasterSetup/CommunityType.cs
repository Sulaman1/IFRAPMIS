using DAL.Models.Domain.SocialMobilization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class CommunityType
    {
        [Key]
        public int CommunityTypeId { get; set; }
        [Required]
        [Display(Name = "Community Type")]
        public string Name { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Code cannot exceeding from 3 digit")]
        public string Code { get; set; }

        //Navigations
        public CICIG? CICIG { get; set; }
    }
}
