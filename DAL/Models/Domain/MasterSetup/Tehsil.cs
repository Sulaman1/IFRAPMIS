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
        public int DistrictId { get; set; }

        //Collections
        public ICollection<UnionCouncil>? UnionCouncils { get; set; }
        
        //Navigations
        public District? District { get; set; }
    }
}
