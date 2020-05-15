using PurchaSaler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Domain.IRepositories
{
    public interface IAddressRepository
    {
        List<Address> GetAllAddress(int userid);
        void AddAddress(Address address);
        void ModifyAddress(Address address);
        void DelAddress(int addressid);
    }
}
