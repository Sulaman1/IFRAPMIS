using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class Provience
    {
        [Key]
        public int ProvienceId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Code cannot exceeding from 3 digit")]
        public string Code { get; set; }

        //Collections
        public ICollection<Division>? Division { get; set; }
    }

}
