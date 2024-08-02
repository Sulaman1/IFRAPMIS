using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TrainingHead
    {
        [Key]
        public int? TrainingHeadId {get; set; }
        public string? TrainingHeadName { get; set; }
        public int CICIGTrainingsId { get; set; }
        public CICIGTrainings? CICIGTrainings { get;set; }
    }
}
