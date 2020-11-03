using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Service.Boards;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardManger_FrontEnd.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
  
    public class BoardController : ControllerBase
    {
        private IBoardService _boardService;
        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }
        [Route("api/BoardController/getAllBoards")]
        
        public List<Board> getAllBoards()
        {
            return _boardService.getAllBoard();
        }
    }
}