using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarInsurance.Models
{
    public class Policy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Policy Name")]
        public required string Name { get; set; }
        [Required]
        [MaxLength(200)]
        [DisplayName("Policy Warranty")]
        public required string Warranty { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Policy Base Cost")]
        public required double BaseCost { get; set; }
        [Required]

        [DisplayName("Policy Annual Cost")]
        public required double AnnualCost { get; set; }

        [MaxLength(200)]
        [DisplayName("Policy Annual Description")]
        public required string Description { get; set; }

    }
}
