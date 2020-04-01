using PurchaSaler.Domain.Entities;
using PurchaSaler.Infrastructure.ORM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PurchaSaler.Infrastructure.Repositories
{
    public class UsersRepository
    {
        private readonly PurchaSalerDbContext _db;
        public UsersRepository(PurchaSalerDbContext db)
        {
            _db = db;
        }

        public Users GetUserByID(Guid id)
        {
            var user = (from u in _db.Users
                        where u.ID == id
                        select u).FirstOrDefault();
            return user;
        }
        public Users GetUserByName(string name)
        {
            var user = (from u in _db.Users
                        where u.UserName == name
                        select u).FirstOrDefault();
            return user;
        }
        public List<Users> GetUsersAll()
        {
            var users = _db.Users.ToList();
            return users;
        }
        public void AddUser(Users user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        public void DelUser(Guid id)
        {
            var delObj = _db.Users.Where(u => u.ID == id).FirstOrDefault();
            _db.Remove(delObj);
            _db.SaveChanges();
        }
    }
}
