using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class UnionCouncil
    {
        [Key]
        public int UnionCouncilId { get; set; }
        public string? UnionCouncilName { get; set; }

        //Connections
        public int TehsilId { get; set; }
        public Tehsil? Tehsil { get; set; }

        //Collections
        public ICollection<Village>? Villages { get; set; }
    }
}
