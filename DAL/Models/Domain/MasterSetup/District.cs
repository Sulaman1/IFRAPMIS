using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }

        [Required]
        //[Display(Name = "District")]
        public required string DistrictName { get; set; }

        //[Required]
        [MaxLength(3, ErrorMessage = "Code cannot exceeding from 3 digit")]
        public required string Code { get; set; }


        //Connections

        [ForeignKey("Division")]
        //[Display(Name = "Division")]
        public int DivisionId { get; set; }
        public Division? Division { get; set; }

        //Collections
        public ICollection<Tehsil>? Tehsils { get; set; }

        //Navigation
        public Trainer? Trainer { get; set; }
    }
}
