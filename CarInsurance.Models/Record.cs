using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInsurance.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public ApplicationUser? ApplicationUser { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Customer Name")]
        public required string CustomerName { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Customer Address")]
        public required string CustomerAddress { get; set; }

        [Required]
        [DisplayName("Customer Phone Number")]
        [Phone]
        public required string CustomerPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Vehicle Policy Type")]
        public required string VehiclePolicyType { get; set; }


        [Required]
        [DisplayName("Policy Date")]
        public DateTime PolicyDate { get; set; }

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
        [MaxLength(200)]
        [DisplayName("Customer Add Prove")]
        public required string CustomerAddProve { get; set; }

        [Required]
        [DisplayName("Insurance Cost")]
        public double InsuranceCost { get; set; }

        [Required]
        [DisplayName("Payment Status")]
        public string PaymentStatus { get; set; } = "Pending Payment";


        [Required]
        [DisplayName("Updated At")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}
