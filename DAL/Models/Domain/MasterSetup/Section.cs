using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class Section
    {
        [Key]
        [Display(Name = "Section")]
        public int SectionId { get; set; }
        [Required]
        [Display(Name = "Section")]
        public string? Name { get; set; }

        public ICollection<Trainer> Trainers { get; set; }
    }
}
