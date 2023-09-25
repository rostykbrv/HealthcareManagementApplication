using System.ComponentModel.DataAnnotations;

namespace HealthcareManagementApplication.Models
{
    public class Facility
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
