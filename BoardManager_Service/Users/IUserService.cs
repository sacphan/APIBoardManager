using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardManager_Service.Users
{
    public interface IUserService
    {
        ErrorObject CreateUser(UserProfile user);
        ErrorObject Login(string Username, string Password);
        ErrorObject UpdateProfile(UserProfile userProfile);
        ErrorObject Profile(int id);
    }
}
