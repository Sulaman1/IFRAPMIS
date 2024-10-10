using DAL.Models.Domain.MasterSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.ViewModels
{
    public class ToolSummary3
    {
        [Key]
        public long RowNumber { get; set; }
        public int? ToolId { get; set; }
        public string? Name { get; set; }
        public int? Counter { get; set; }
        public string? MD { get; set; }
        public string? MD1 { get; set; }
        public string? MD2 { get; set; }
        public string? MD3 { get; set; }
        public string? Description { get; set; }
        public string? UserName { get; set; }
        public string? CurrentDateTime { get; set; }
        public double? Latitute { get; set; }
        public double? Longitute { get; set; }
        public string? ControlLebel { get; set; }
        public string? ControlName { get; set; }
        public string? Response { get; set; }
        public string? Version { get; set; }
        public int? IsOffline { get; set; }
    }
}
