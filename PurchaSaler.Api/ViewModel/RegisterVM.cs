﻿using PurchaSaler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaSaler.Api.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "请输入用户名")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "请输入邮箱")]
        //public string Email { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }
    }
}
