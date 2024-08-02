using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public ICollection<Tehsil>? Tehsils { get; set; }
    }
}
