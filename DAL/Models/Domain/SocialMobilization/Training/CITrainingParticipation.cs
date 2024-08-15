using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.SocialMobilization.Training
{
    public class CITrainingParticipation
    {
        [Key]
        public int CIIrainingParticipationId { get; set; }
        public int CICIGId { get; set; }
        [ForeignKey("CICIGId")]
        public CICIG? CICIG { get; set; }


        public int CICIGTrainingsId { get; set; }
        public CICIGTrainings? CICIGTrainings { get; set; }
    }
}
