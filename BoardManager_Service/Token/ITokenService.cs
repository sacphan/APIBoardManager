using BoardManager_Data.BoardManagerContext.Models;
using ShipTo.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardManager_Service.Token
{
    public interface ITokenService
    {
        AuthToken CreateToken(UserProfile user);
        AuthToken RefreshToken(string RefreshToken);
    }
}
