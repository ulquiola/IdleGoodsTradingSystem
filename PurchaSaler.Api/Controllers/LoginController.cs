using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PurchaSaler.Api.Entity;
using PurchaSaler.Api.Services;
using System.Linq;
using System.Security.Claims;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/login")]
    [EnableCors("any")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PurchaSalerDbContext _db;
        private readonly IConfiguration _config;
        public LoginController(PurchaSalerDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [HttpPost]
        public IActionResult Login(Users user)
        {
            //添加测试用例
            //user.UserName = "ulquiola";
            //user.Email = "ulquiola@163.com";
            //user.Password = "123456";
            //_db.Users.Add(user);
            //_db.SaveChanges();
            //return Ok();

            //取出这个人的信息
            var man = (from m in _db.Users
                       where m.UserName == user.UserName
                       select m).FirstOrDefault();
            //验证该用户是否存在
            if (man!= null)
            {
                //验证密码
                if (user.Password == man.Password)
                {
                    //生成token
                    var jwt = new JsonWebToken(_config);
                    var token = jwt.GenerateToken(man);

                    return new JsonResult(token);
                    
                }
                else
                {
                    return StatusCode(422, "密码错误");
                }
            }
            else
            {
                return StatusCode(422, "用户不存在");
            }
        }
    }
}