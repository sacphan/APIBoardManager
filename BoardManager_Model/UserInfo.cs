using System;
using System.Collections.Generic;
using System.Text;
using BoardManager_Data.BoardManagerContext.Models;
namespace BoardManager_Model
{
    public class UserInfo
    {
        public UsersAccount userAccount { set; get; }

        public UserProfile UserProfile { set; get; }
        public FacebookAccount facebookAccount { get; set; }
        public GoogleAccount googleAccount { get; set; }
    }
}
