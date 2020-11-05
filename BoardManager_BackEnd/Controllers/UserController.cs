using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Model;
using BoardManager_Service.Token;
using BoardManager_Service.Users;
using BoardManager_Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;

namespace BoardManager_BackEnd.Controllers
{
   
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        
        private IConfiguration _config;
        private IUserService _IUserService;
        private ITokenService _TokenService;
        private IMapper _Mapper;
        public UserController(IConfiguration config, IUserService userService, ITokenService tokenService,IMapper mapper)
        {
            _config = config;
            _IUserService = userService;
            _TokenService = tokenService;
            _Mapper = mapper;
        }
        [Route("api/login")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] JObject login)
        {
         
            //IActionResult response = Unauthorized();
            var error = new ErrorObject(Error.SUCCESS);
            try
            {
                JToken jToken;
                if (!login.TryGetValue("username", out jToken)) return Ok(error.Failed("username invalid."));
                var username = jToken.Value<string>();
                if (!login.TryGetValue("password", out jToken)) return Ok(error.Failed("password invalid."));
                var password = jToken.Value<string>();

                var result = _IUserService.Login(username, password);
                if (result.Code == Error.SUCCESS.Code)
                {
                 
                    var token = _TokenService.CreateToken(result.GetData<UsersAccount>());
                    return Ok(error.SetData(token));
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return Ok(error.System(ex));
            }
        }
        [Route("api/register")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterModel model)
        {

            //IActionResult response = Unauthorized();
            var error = new ErrorObject(Error.SUCCESS);
            try
            {
                var userinfo = _Mapper.Map<UserInfo>(model);
                error = _IUserService.CreateUser(userinfo);
                if (error.Code == Error.SUCCESS.Code)
                {
                    _User = error.GetData<UsersAccount>();
                    var token = _TokenService.CreateToken(error.GetData<UsersAccount>());
                    return Ok(error.SetData(token));
                }
                return Ok(error);             
            }
            catch (Exception ex)
            {
                return Ok(error.System(ex));
            }
        }
        [Route("api/refreshtoken")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult RefreshToken(JObject RefreshToken)
        {
            var error = new ErrorObject(Error.SUCCESS);
            try
            {
                JToken jToken;
                if (!RefreshToken.TryGetValue("refreshToken", out jToken))
                {
                    return Ok(error.Failed("refreshToken invalid."));
                }
                var refreshToken = jToken.Value<string>();
                var token = _TokenService.RefreshToken(refreshToken);
                if (token != null)
                {
                    return Ok(error.SetData(token));
                }
                else
                {
                    return Ok(error.Failed("refreshToken invalid"));
                }
            }
            catch (Exception ex)
            {
                error.Failed(ex.Message);
            }
            return Ok(error);
        }
        [Route("api/updateProfile")]
        [HttpPost]   
        public IActionResult UpdateProfile([FromBody]UserProfile userProfile)
        {
            var error = new ErrorObject(Error.SUCCESS);
            try
            {
                userProfile.Id = _User.UserProfileId;
                error = _IUserService.UpdateProfile(userProfile);
               
            }
            catch (Exception ex)
            {
                error.Failed(ex.Message);
            }
            return Ok(error);
        }
        [Route("api/Profile")]
        [HttpGet]
        public IActionResult Profile()
        {
            var error = new ErrorObject(Error.SUCCESS);
            try
            {
                
                error = _IUserService.Profile(_User.UserProfileId);

            }
            catch (Exception ex)
            {
                error.Failed(ex.Message);
            }
            return Ok(error.GetData<UserProfile>());
        }


    }
}