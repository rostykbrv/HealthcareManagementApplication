using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthcareManagementApplication.Models
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [StringLength(500)]
        public string Instructions { get; set; }

        // Navigation properties
        public virtual Appointment Appointment { get; set; }
    }
}
