using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class Tehsil
    {
        [Key]
        public int TehsilId { get; set; }
        public string? TehsilName { get; set; }
        
        //Connections
        public int DistrictId { get; set; }
        public District? District { get; set; }

        //Collections
        public ICollection<UnionCouncil>? UnionCouncils { get; set; }

    }
}
