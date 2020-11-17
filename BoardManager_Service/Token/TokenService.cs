using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Service.Caching;
using BoardManager_Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShipTo.Lib.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BoardManager_Service.Token
{
    public class TokenService :ITokenService
    {
        private IConfiguration _Configuration;

        private ICacheService _CacheService;
        public TokenService(IConfiguration configuration, ICacheService cacheService)
        {
            _Configuration = configuration;
            _CacheService = cacheService;
        }
        public AuthToken CreateToken(UserProfile user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                user.FacebookAccount = null;
                user.GoogleAccount = null;
                user.UsersAccount = null;
                var claims = new[] {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("User", user.ToJson()),
                    new Claim(ClaimTypes.Email, user.Email),
               
                };
                var token = new JwtSecurityToken(_Configuration["Jwt:Issuer"],
                    _Configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(int.Parse(_Configuration["Jwt:Expire"])),
                    signingCredentials: credentials);
                var bearerToken = new JwtSecurityTokenHandler().WriteToken(token);
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
                var exp = start.AddSeconds(int.Parse(token.Claims.FirstOrDefault(c => c.Type == "exp").Value)).AddHours(7);// VN: utc + 7
                var tokenResult = new AuthToken
                {
                    Token = bearerToken,
                    RefreshToken = Guid.NewGuid().ToString(),
                    Exprire = exp
                };
                var cacheKey = _CacheService.CreateCacheKey(CacheKeyName.RefreshToken, tokenResult.RefreshToken);
                _CacheService.Set(cacheKey, user);
                return tokenResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AuthToken RefreshToken(string RefreshToken)
        {
            try
            {
                //so sánh RefeshToken với cache
                var cacheKey = _CacheService.CreateCacheKey(CacheKeyName.RefreshToken, RefreshToken);
                var user = _CacheService.Get<UsersAccount>(cacheKey);
                if (user != null)
                {
                    _CacheService.Remove(cacheKey);
                    return CreateToken(user.UserProfile);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
