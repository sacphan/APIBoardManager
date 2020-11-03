using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

namespace BoardManager_BackEnd.Controllers
{
   
    [ApiController]

    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _IUserService;
        private ITokenService _TokenService;
       
        public UserController(IConfiguration config, IUserService userService, ITokenService tokenService)
        {
            _config = config;
            _IUserService = userService;
            _TokenService = tokenService;
          
        }
        [Route("api/login")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(JObject login)
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

                var result = _IUserService.Login(username, password.EncryptMd5());
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

        [Route("api/refreshtoken")]
        [HttpPost]
        [Authorize]
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
                throw;
            }
        }
       
    }
}