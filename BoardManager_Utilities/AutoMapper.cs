using AutoMapper;
using BoardManager_Model;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardManager_Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterModel, UserInfo>();
        }
    }
}
