using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInsurance.Models
{
    public class Estimate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public ApplicationUser? ApplicationUser { get; set; }

        [Required]
        [DisplayName("Estimate Number")]
        public int EstimateNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Customer Name")]
        public required string CustomerName { get; set; }

        [Required]
        [DisplayName("Customer Phone Number")]
        [Phone]
        public required string CustomerPhoneNumber { get; set; }

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
        [MaxLength(50)]
        [DisplayName("Vehicle Policy Type")]
        public required string VehiclePolicyType { get; set; }

        // Foreign key relationship to Policy model
        [Required]
        [DisplayName("Policy ID")]
        public int PolicyId { get; set; }

        [ForeignKey("PolicyId")]
        public Policy Policy { get; set; }

        [Required]
        [DisplayName("Vehicle ID")]
        public int VehicleId { get; set; }



        [Required]
        [DisplayName("Policy Base Cost")]
        public double PolicyBaseCost { get; set; }

        [Required]
        [DisplayName("Policy Annual Cost")]
        public double PolicyAnnualCost { get; set; }

        [Required]
        [DisplayName("Estimate Cost")]
        public double EstimateCost { get; set; }
    }

}
