using System.Linq;
using System.Web.Http;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
                _context=new ApplicationDbContext();
        }
  
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO dto)
        {
            string attendeeId= User.Identity.GetUserId();
            if (_context.Attendances.Any(a => a.GigId == dto.GigId && a.AttendeeId == attendeeId))
                return BadRequest("The Attendance Already exists");

            var attendance = new Attendance()
            {
                AttendeeId =attendeeId ,
               
                GigId = dto.GigId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
