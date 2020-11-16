using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BoardManager_Core;
using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Service.WorkContext;
using Microsoft.AspNetCore.Mvc;


namespace BoardManager_BackEnd.Controllers
{
    public class BaseController : Controller
    {

        protected IWorkContext _WorkContext = EngineContext.Resolve<IWorkContext>();
      

        public UserProfile _User { get => _WorkContext.CurrentUser; set => _WorkContext.CurrentUser = value; }

    }
}