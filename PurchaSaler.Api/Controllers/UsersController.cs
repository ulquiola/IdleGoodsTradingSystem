using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Infrastructure.ORM;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("any")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PurchaSalerDbContext _db;
        public UsersController(PurchaSalerDbContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpGet("GetUserName")]
        public IActionResult GetUserName()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

            var username = (from u in _db.Users
                            where u.ID.ToString() == userId
                            select u.UserName).FirstOrDefault();

            return Ok($"welcome {username} !");
        }
    }
}