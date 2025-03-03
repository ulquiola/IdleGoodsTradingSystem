﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt;
using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Api.Services;
using Microsoft.Extensions.Configuration;
using PurchaSaler.Api.ViewModel;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("any")]
    [ApiController]
    public class UsersController : CorsController
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _environment;

        public UsersController(IUsersRepository usersRepository, IConfiguration config, IWebHostEnvironment environment)
        {
            _usersRepository = usersRepository;
            _config = config;
            _environment = environment;
        }

        [HttpPost("Register")]
        public IActionResult Register(Users user)
        {
            bool IsExisted = _usersRepository.IsExisted(user.UserName);
            if(ModelState.IsValid && !IsExisted)
            {
                //哈希密码
                user.Password = EncryptProvider.Md5(user.Password);
                var man = new Users()
                {
                    //UserId 主键自增
                    UserName = user.UserName,
                    Name = "",
                    Avatar = "img/defaultAvt.png",
                    Birthday = DateTime.Now.ToString("D"),
                    Sex = "保密",
                    Email = "",
                    Password = user.Password
                };
                _usersRepository.AddUser(man);
                return Ok("注册成功");
            }
            else
            {
                return StatusCode(422,"用户已存在");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginVM user)
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

        [Authorize]
        [HttpGet("UserInfo")]
        public IActionResult UserInfo()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userid =Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            var man = _usersRepository.GetUserByID(userid);
            //密码置空，不返回密码
            man.Password = "";
            return new JsonResult(man);
        }

        [Authorize]
        [HttpPost("UpdateInfo")]
        public IActionResult UpdateInfo(UpdateInfoVM infoVM)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userid = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            var man = _usersRepository.GetUserByID(userid);
                man.Name = infoVM.Name;
                man.Birthday = infoVM.Birthday;
                man.Email = infoVM.Email;
                man.Sex = infoVM.Sex;
            _usersRepository.ModifyUser(man);
            return Ok();
        }

        [Authorize]
        [HttpPost("UpdateAvatar")]
        public IActionResult UpdateAvatar(IFormFile file)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userid = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            var man = _usersRepository.GetUserByID(userid);

            var upload = new UploadImages(_environment);
            string avatar = upload.Upload(file);
            man.Avatar = avatar;
            _usersRepository.ModifyUser(man);
            return Ok();
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