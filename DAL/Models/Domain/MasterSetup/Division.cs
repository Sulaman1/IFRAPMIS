using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class Division
    {
        [Key]
        public int DivisionId { get; set; }
        [Required]
        [Display(Name = "Division")]
        public string Name { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Code cannot exceeding from 3 digit")]
        public string Code { get; set; }
        public string? Description { get; set; }       

        //Connections
        [ForeignKey("Provience")]
        public int ProvienceId { get; set; }
        public Provience? Provience { get; set; }
        
        //Collections
        public ICollection<District>? District { get; set; }
    }

}
