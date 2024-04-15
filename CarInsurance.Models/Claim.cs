using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInsurance.Models
{
    public class Claim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        public required string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public ApplicationUser? ApplicationUser { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Customer Name")]
        public required string CustomerName { get; set; }

        [Required]
        [DisplayName("Billing ID")]
        public required int BillingId { get; set; }

        [ForeignKey("BillingId")]
        public Billing? Billing { get; set; }


        [DisplayName("Bill No.")]
        public required string BillNo { get; set; }


        [MaxLength(50)]
        [DisplayName("Vehicle Policy Type")]
        public required string VehiclePolicyType { get; set; }


        [Required]
        [DisplayName("Policy Start Date")]
        public DateTime PolicyStartDate { get; set; }

        [Required]
        [DisplayName("Policy End Date")]
        public DateTime PolicyEndDate { get; set; }

        [Required]
        [DisplayName("Policy Duration")]
        public string PolicyDuration { get; set; } = "1 year";

        [Required]
        [MaxLength(50)]
        [DisplayName("Vehicle Name")]
        public required string VehicleName { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Vehicle Model")]
        public required string VehicleModel { get; set; }

        [Required]
        [DisplayName("Vehicle Number")]
        [StringLength(8)]
        public required string VehicleNumber { get; set; }

        [Required]
        [DisplayName("Vehicle Version")]
        public required string VehicleVersion { get; set; }

        [Required]
        [DisplayName("Vehicle Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal VehicleValue { get; set; }

        [Required]
        [DisplayName("Vehicle Rate")]
        public int VehicleRate { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("Vehicle Warranty")]
        public required string VehicleWarranty { get; set; }


        [Required]
        [DisplayName("Insurance Cost")]
        public double InsuranceCost { get; set; }


        [Required]
        [MaxLength(200)]
        [DisplayName("Place Of Accident")]
        public required string PlaceOfAccident { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("Date Of Accident")]
        public required DateTime DateOfAccident { get; set; }

        [Required]
        [DisplayName("Insurance Amount")]
        public double InsuranceAmount { get; set; }

        [Required]
        [DisplayName("Claimable Amount")]
        public double ClaimableAmount { get; set; }


    }

}
