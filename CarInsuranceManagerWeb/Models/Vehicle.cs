using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManagerWeb.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string OwnerName { get; set; }
        [Required]
        public required string Model { get; set; }
        [Required]
        public required string Version { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public required string BodyNumber { get; set; }
        [Required]
        public required string EngineNumber { get; set; }
        [Required]
        public required string Number { get; set; }

    }
}
