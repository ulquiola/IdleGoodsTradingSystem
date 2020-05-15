using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Infrastructure.ORM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PurchaSaler.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly PurchaSalerDbContext _db;

        public AddressRepository(PurchaSalerDbContext db)
        {
            _db = db;
        }
        public void AddAddress(Address address)
        {
            _db.Addresses.Add(address);
            _db.SaveChanges();
        }

        public void DelAddress(int addressid)
        {
            var address = _db.Addresses.Find(addressid);
            _db.Addresses.Remove(address);
            _db.SaveChanges();
        }

        public List<Address> GetAllAddress(int userid)
        {
            var data = (from d in _db.Addresses
                        where d.UserID == userid
                        select d).ToList();
            return data;
        }

        public void ModifyAddress(Address address)
        {
            _db.Entry(address).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
