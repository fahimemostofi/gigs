using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    
    [Authorize]
    public class FollowingController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingController()
        {
                _context=new ApplicationDbContext();
        }
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Followings.Any(p => p.FollowerId==userId && p.FolloweeId==dto.ArtistId))
            {
                return BadRequest("Following already exist!");
            }

            var following = new Following
            {
                FollowerId = userId,
               
                FolloweeId = dto.ArtistId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();
            return Ok();
        }
    }
}
