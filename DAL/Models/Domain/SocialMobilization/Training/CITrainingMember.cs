using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.SocialMobilization.Training
{
    public class CITrainingMember
    {
        [Key]
        public int CITrainingMemberId { get; set; }

        //Connections
        public int CIMemberId { get; set; }
        public CIMember? CIMember { get; set; }        
        public int CICIGTrainingsId { get; set; }
        public CICIGTrainings? CICIGTrainings { get; set; }
    }
}
