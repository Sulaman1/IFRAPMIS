using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UnionCouncil
    {
        [Key]
        public int UnionCouncilId { get; set; }
        public string? UnionCouncilName { get; set; }
        public int TehsilId { get; set; }
        public Tehsil? Tehsil { get;set; }
        public ICollection<Village>? Villages { get; set; }
    }
}
