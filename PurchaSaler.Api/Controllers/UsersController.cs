using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt;
using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Api.Services;
using Microsoft.Extensions.Configuration;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("any")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguration _config;

        public UsersController(IUsersRepository usersRepository, IConfiguration config)
        {
            _usersRepository = usersRepository;
            _config = config;
        }

        [HttpPost("Register")]
        public IActionResult Register(Users user)
        {
            bool IsExisted = _usersRepository.IsExisted(user.UserName);
            if(ModelState.IsValid && !IsExisted)
            {
                //哈希密码
                user.Password = EncryptProvider.Md5(user.Password);
                _usersRepository.AddUser(user);
                return Ok("注册成功");
            }
            else
            {
                return StatusCode(422,"用户已存在");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(Users user)
        {
            if (ModelState.IsValid)
            {
                bool IsExisted = _usersRepository.IsExisted(user.UserName);
                //用户是否存在
                if(IsExisted)
                {
                    //取出这个人的信息
                    var man = _usersRepository.GetUserByName(user.UserName);
                    //验证密码
                    if (EncryptProvider.Md5(user.Password) == man.Password)
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
            else
            {
                return StatusCode(422, "实体验证失败");
            }
        }



        //[Authorize]
        //[HttpGet("GetUserName")]
        //public IActionResult GetUserName()
        //{
        //    var claimsIdentity = User.Identity as ClaimsIdentity;
        //    var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

        //    var username = (from u in _db.Users
        //                    where u.UserID.ToString() == userId
        //                    select u.UserName).FirstOrDefault();

        //    return Ok($"welcome {username} !");
        //}
    }
}