using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TrainingTitle
    {
        [Key]

        public int TitleId { get; set; }
        public string? TrainingName  { get; set; }
        public int CICIGTrainingsId {  get; set; }
        public CICIGTrainings? CICIGTrainings { get; set; }    
    }
}
