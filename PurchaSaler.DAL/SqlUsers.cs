using System;
using System.Collections.Generic;
using System.Text;
using PurchaSaler.Models;
using System.Linq;

namespace PurchaSaler.DAL
{
    public class SqlUsers
    {
        private readonly PurchaSalerDbContext _db;
        public SqlUsers(PurchaSalerDbContext db)
        {
            _db = db;
        }

        public Users GetUserByID(Guid id)
        {
            var user = (from u in _db.Users
                        where u.id == id
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
            var delObj = _db.Users.Where(u => u.id == id).FirstOrDefault();
            _db.Remove(delObj);
            _db.SaveChanges();
        }
    }
}
