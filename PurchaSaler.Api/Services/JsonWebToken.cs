using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PurchaSaler.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PurchaSaler.Api.Services
{
    public class JsonWebToken
    {
        private readonly IConfiguration _config;
        public JsonWebToken(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(Users userinfo)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //使用Name存储用户id,以便取出
                    new Claim(ClaimTypes.Name, userinfo.UserID.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(2),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSetting:secretkey"])),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }
        public SecurityToken DecodeToken(string encodetoken)
        {
            var json = new JwtSecurityTokenHandler().ReadToken(encodetoken);
            return json;
        }
    }
}
