using HealthcareManagementApplication.Data;
using HealthcareManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManagementApplication.Controllers
{
    public class MedicationController:ControllerBase
    {
        private readonly HealthcareManagementDbContext _context;

        public MedicationController(HealthcareManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetMedications()
        {
            return await _context.Medications.Include(m => m.Appointment).ToListAsync();
        }

        // GET: api/Medications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetMedication(int id)
        {
            var medication = await _context.Medications.Include(m => m.Appointment).FirstOrDefaultAsync(m => m.Id == id);

            if (medication == null)
            {
                return NotFound();
            }

            return medication;
        }
    }
}
