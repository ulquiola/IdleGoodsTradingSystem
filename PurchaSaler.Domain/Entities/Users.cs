using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class Users
    {
        //7
        [Key]
        public int UserID { get; set; }//id
        
        [Required(ErrorMessage = "请输入用户名")]        
        public string UserName { get; set; }  //用户名
        public string Name { get; set; }//姓名      

        public string Avatar { get; set; } //头像
        public string Email { get; set; }//邮箱

        public string Birthday { get; set; }//生日
        public string Sex { get; set; }//性别

        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; } //密码


    }
}
