using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Api.ViewModel;
using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : CorsController
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        [Authorize]
        [HttpGet("GetAddressList")]
        public IActionResult GetAddressList()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userid = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            var data = _addressRepository.GetAllAddress(userid);
            return new JsonResult(data);
        }
        [Authorize]
        [HttpPost("Add")]
        public IActionResult Add([FromBody]AddressVM addressVM)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userid = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            //8
            Address address = new Address()
            {
                //主键自增
                UserID = userid,
                name = addressVM.name,
                phone = addressVM.phone,
                Province = addressVM.Province,
                City = addressVM.City,
                County = addressVM.County,
                AddressDetail = addressVM.AddressDetail,
            };
            _addressRepository.AddAddress(address);
            return Ok("添加成功");
        }
        [Authorize]
        [HttpPost("Modify")]
        public IActionResult Modify([FromBody]Address address)
        {
            _addressRepository.ModifyAddress(address);
            return Ok("修改成功");
        }
        [Authorize]
        [HttpPost("Delete")]
        public IActionResult Delete(RequestId id)
        {
            int addressid = id.Id;
            _addressRepository.DelAddress(addressid);
            return Ok("删除成功");
        }

    }
}