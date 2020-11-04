using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Service.Boards;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BoardManager_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private IBoardService _boardService;

        public WeatherForecastController(IBoardService boardService)
        {
            _boardService = boardService;
        }

       
    }
}
