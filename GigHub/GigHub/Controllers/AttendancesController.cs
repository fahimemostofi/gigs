using System.Web.Http;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
   
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
                _context=new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody]int gigId)
        {
            var attendance = new Attendance()
            {
                AttendeeId = User.Identity.GetUserId(),
               
                GigId = gigId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
