using HealthcareManagementApplication.Data;
using HealthcareManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController:ControllerBase
    {
        private readonly HealthcareManagementDbContext _context;

        public AppointmentController(HealthcareManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.Include(a => a.Patient).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.Include(a => a.Patient).FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }
    }
}
