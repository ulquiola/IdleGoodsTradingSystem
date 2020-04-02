using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class Users
    {
        [Key]
        public Guid UserID { get; set; }

        [Required(ErrorMessage ="请输入用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请输入邮箱")]
        public string Email { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }
    }
}
