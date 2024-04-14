using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInsurance.Models
{
    public class Billing
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
        [DisplayName("Policy Start Date")]
        public DateTime PolicyStartDate { get; set; }

        [Required]
        [DisplayName("Policy End Date")]
        public DateTime PolicyEndDate { get; set; }

        [Required]
        [DisplayName("Policy Duration")]
        public string PolicyDuration { get; set; } = "1 year";

        [Required]
        [DisplayName("Bill No.")]
        public string BillNo { get; set; } = Guid.NewGuid().ToString();

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
        [DisplayName("Payment Amount")]
        public double Amount { get; set; }

        [Required]
        [DisplayName("Billing At")]
        public DateTime BillingAt { get; set; } = DateTime.Now;
    }

}


