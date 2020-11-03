using BoardManager_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardManager_Service.Users
{
    public interface IUserService
    {
        ErrorObject CreateUser(UserInfo user);
        ErrorObject Login(string Username, string Password);
    }
}
