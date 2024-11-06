using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain.MasterSetup;

namespace DAL.Models.Domain.Damage
{
    public class DamagePDMA
    {
        [Key]
        public int DamagePDMAId { get; set; }
        //Building
        public int? DamageHouseNoOfRooms { get; set; }
        public string? DamageHouseCategory { get; set; }
        public int? DamageShopNoOfRooms { get; set; }
        public string? DamageShopCategory { get; set; }
        public int? DamageOtherNoOfRooms { get; set; }
        public string? DamageOtherCategory { get; set; }
        //Crops
        public double? CropLandArea { get; set; }
        public string? OtherLandName { get; set; }
        public double? OtherLandArea { get; set; }

        //Fruits
        public int? NumberOfTrees { get; set; }
        public string? OtherTreeName { get; set; }
        public int? OtherTreeNumber { get; set; }

        //Livestocks
        public int? NumberOfAnimals { get; set; }
        public string? OtherAnimalName { get; set; }
        public int? OtherAnimalNumber { get; set; }

        public string? Attachment { get; set; }

        //Connections
        public int BeneficiaryPDMAId { get; set; }
        public BeneficiaryPDMA? BeneficiaryPDMA { get; set; }
        public int DamageAssessmentHTSId { get; set; }
        public DamageAssessmentHTS? DamageAssessmentHTS { set; get; }
        public int DamageAssessmentLivestockId { get; set; }
        public DamageAssessmentLivestock? DamageAssessmentLivestock { set; get; }
        public int DamageAssessmentBuildingId { get; set; }
        public DamageAssessmentBuilding? DamageAssessmentBuilding { set; get; }
    }
}
