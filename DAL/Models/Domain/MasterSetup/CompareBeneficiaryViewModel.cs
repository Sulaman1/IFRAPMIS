using DAL.Models.Domain.Damage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.MasterSetup
{
    public class CompareBeneficiaryViewModel
    {
        public BeneficiaryIP BeneficiaryIP { get; set; }
        public BeneficiaryPDMA BeneficiaryPDMA { get; set; }
        public DamageIP DamageIP { get; set; }
        public DamagePDMA DamagePDMA { get; set; }

        // Properties for the verified data
        [Required(ErrorMessage = "Name is required")]
        public string? VerifiedName { get; set; }

        [Required(ErrorMessage = "Father Name is required")]
        public string? VerifiedFather { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? VerifiedGender { get; set; }

        //[Required(ErrorMessage = "CNIC is required")]
        //[StringLength(13, MinimumLength = 13, ErrorMessage = "CNIC must be 13 digits")]
        public string? VerifiedCNIC { get; set; }

        [Required(ErrorMessage = "MOb Number is required")]
        public string? VerifiedMobile { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int? VerifiedAge { get; set; }

        [Required(ErrorMessage = "MaritialStatus is required")]
        public string? VerifiedMaritialStatus { get; set; }
        public bool VerifiedIsDisable { get; set; }

        //[Required(ErrorMessage = "CNICAttachment is required")]
        public string? VerifiedCNICAttachment { get; set; }
        public bool VerifiedIsRefugee { get; set; }
        public byte[]? VerifiedProfilePicture { get; set; }

        [Required(ErrorMessage = "District is required")]
        public string? VerifiedDistrict { get; set; }

        [Required(ErrorMessage = "Tehsil is required")]
        public string? VerifiedTehsil { get; set; }

        [Required(ErrorMessage = "UnionCouncil is required")]
        public string? VerifiedUnionCouncil { get; set; }

        [Required(ErrorMessage = "Survey Date is required")]
        public DateTime? VerifiedSurveyDate { get; set; }

        [Required(ErrorMessage = "Nextofkin Name is required")]
        public string? VerifiedNextOfKin { get; set; }

        [Required(ErrorMessage = "Nextofkin CNIC is required")]
        public string? VerifiedNextOfKinCNIC { get; set; }

        [Required(ErrorMessage = "IdentifiedBy Name is required")]
        public string? VerifiedIdentifiedFor { get; set; }

        //Building
        public int? VerifiedDamageHouseNoOfRooms { get; set; }
        public string? VerifiedDamageHouseCategory { get; set; }
        public int? VerifiedDamageShopNoOfRooms { get; set; }
        public string? VerifiedDamageShopCategory { get; set; }
        public int? VerifiedDamageOtherNoOfRooms { get; set; }
        public string? VerifiedDamageOtherCategory { get; set; }
        //Crops
        public double? VerifiedCropLandArea { get; set; }
        public string? VerifiedOtherLandName { get; set; }
        public double? VerifiedOtherLandArea { get; set; }

        //Fruits
        public int? VerifiedNumberOfTrees { get; set; }
        public string? VerifiedOtherTreeName { get; set; }
        public int? VerifiedOtherTreeNumber { get; set; }

        //Livestocks
        public int? VerifiedNumberOfAnimals { get; set; }
        public string? VerifiedOtherAnimalName { get; set; }
        public int? VerifiedOtherAnimalNumber { get; set; }

        public string? VerifiedAttachment { get; set; }

        //Keys
        public int? BeneficiaryIPId { get; set; }
        public int? BeneficiaryPDMAId { get; set; }
        public int? DamagePDMAId { get; set; }
        public int? DamageIPId { get; set; }
        public int? SurveyTeamIPId { get; set; }
        public int? SurveyTeamPDMAId { get; set; }

    }
}
