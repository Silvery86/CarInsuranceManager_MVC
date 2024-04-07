using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInsurance.Models
{
    public class Vehicle
    {
        public string UserName;

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Vehicle Name")]
        public required string Name { get; set; }

        [Required]
        [DisplayName("Owner Name")]
        public required string OwnerName { get; set; }

        [Required]
        [DisplayName("Vehicle Model")]
        public required string Model { get; set; }

        [Required]
        [DisplayName("Vehicle Version")]
        public required string Version { get; set; }

        [Required]
        [DisplayName("Vehicle Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal VehicleValue { get; set; }

        [Required]
        [Range(1, 100)]
        [DisplayName("Vehicle Rate")]
        public int Rate { get; set; }

        [Required]
        [MaxLength(25)]
        [DisplayName("Vehicle Body Number")]
        public required string BodyNumber { get; set; }

        [Required]
        [MaxLength(25)]
        [DisplayName("Vehicle Engine Number")]
        public required string EngineNumber { get; set; }

        [Required]
        [DisplayName("Vehicle Number")]
        [StringLength(8)]
        public required string Number { get; set; }

        // Navigation property for the associated user
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? IdentityUser { get; set; }
    }
}