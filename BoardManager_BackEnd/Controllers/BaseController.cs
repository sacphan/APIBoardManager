using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BoardManager_Data.BoardManagerContext.Models;
using Microsoft.AspNetCore.Mvc;



namespace BoardManager_BackEnd.Controllers
{
    public class BaseController : Controller
    {

        public static UsersAccount _User;


    }
}