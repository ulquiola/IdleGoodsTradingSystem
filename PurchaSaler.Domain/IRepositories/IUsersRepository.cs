using PurchaSaler.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PurchaSaler.Domain.IRepositories
{
    public interface IUsersRepository
    {
        bool IsExisted(string username);
        Users GetUserByID(int userid);
        Users GetUserByName(string username);
        List<Users> GetAllUsers();
        void AddUser(Users user);
        void DelUser(int userid);
        void ModifyUser(Users user);
    }
}
