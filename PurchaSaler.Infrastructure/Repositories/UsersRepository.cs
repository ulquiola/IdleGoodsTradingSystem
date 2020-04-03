using PurchaSaler.Domain.Entities;
using PurchaSaler.Infrastructure.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using PurchaSaler.Domain.IRepositories;

namespace PurchaSaler.Infrastructure.Repositories
{
    public class UsersRepository:IUsersRepository
    {
        private readonly PurchaSalerDbContext _db;
        public UsersRepository(PurchaSalerDbContext db)
        {
            _db = db;
        }

        public void AddUser(Users user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void DelUser(Guid userid)
        {
            var delObj = _db.Users.Where(u => u.UserID == userid).FirstOrDefault();
            _db.Remove(delObj);
            _db.SaveChanges();
        }

        public List<Users> GetAllUsers()
        {
            var users = _db.Users.ToList();
            return users;
        }

        public Users GetUserByID(Guid userid)
        {
            var user = (from u in _db.Users
                        where u.UserID == userid
                        select u).FirstOrDefault();
            return user;
        }

        public Users GetUserByName(string username)
        {
            var user = (from u in _db.Users
                        where u.UserName == username
                        select u).FirstOrDefault();
            return user;
        }

        public bool IsExisted(string username)
        {
            var user = (from u in _db.Users
                        where u.UserName == username
                        select u).FirstOrDefault();
            return user == null ? false:true;
        }
    }
}
