﻿using BoardManager_Data.BoardManagerContext;
using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Model;
using BoardManager_Service.Caching;
using BoardManager_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardManager_Service.Users
{

    public class UserService : IUserService
    {
        public ICacheService _cacheService { get; set; }
        public UserService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public ErrorObject CreateUser(UserProfile user)
        {
            var error = Error.Success();
            try
            {
                var userAccount = user.UsersAccount.First();
                userAccount.PassWord = userAccount.PassWord.EncryptMd5();

                var db = new BoardManagerContext();
                //check username conflict
                if (db.UsersAccount.Any(x => x.UserName.ToLower().Equals(userAccount.UserName.ToLower())))
                {
                    return Error.USER_EXISTED;
                }             
                db.UserProfile.Add(user);
                if (db.SaveChanges() > 0) {
                    userAccount.UserProfile.UsersAccount = null;
                    return error.SetData(userAccount);
                }
                
                return error.Failed("Create user failed");                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ErrorObject Login(string Username, string Password)
        {
            var error = Error.Success();
            try
            {
                using var db = new BoardManagerContext();
                var user = db.UsersAccount.FirstOrDefault(x => x.UserName.ToLower().Equals(Username.ToLower()) && x.PassWord.Equals(Password.EncryptMd5()));
                if (user != null)
                {
                    return error.SetData(user);
                }
                else
                {
                    return Error.USER_INVALID;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ErrorObject UpdateProfile(UserProfile userProfile)
        {
            var error = Error.Success();
            try
            {

                using var db = new BoardManagerContext();
                var user = db.UserProfile.FirstOrDefault(x => x.Id == userProfile.Id);

                if (userProfile != null)
                {
                    user.Firstname = userProfile.Firstname;
                    user.LastName = userProfile.LastName;
                    user.Email = userProfile.Email;
                    db.SaveChanges();
                    return error.SetData(user);
                }
                else
                {
                    return Error.USER_INVALID;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ErrorObject Profile(int id)
        {
            var error = Error.Success();
            try
            {
                using var db = new BoardManagerContext();
                var user = db.UserProfile.FirstOrDefault(x => x.Id == id);
                return error.SetData(user);
            }
            catch(Exception ex)
            {
                return error.Failed(ex.Message);
            }
        }
        public ErrorObject LoginFacebook(LoginFacebook  loginFacebook)
        {
            var error = Error.Success();
            try
            {
                using var db = new BoardManagerContext();
                var userProfile = new UserProfile
                {
                    Email = loginFacebook.Email,
                    
                    FacebookAccount = new List<FacebookAccount>()
                    {
                        new FacebookAccount()
                        {
                            FacebookId = loginFacebook.FacebookId,
                            UserName = loginFacebook.Name
                        }
                        
                    }
                };
                db.UserProfile.Add(userProfile);
                db.SaveChanges();
                return error.SetData(userProfile);
            }
            catch (Exception ex)
            {
                return error.Failed(ex.Message);
            }
        }
    }
}
