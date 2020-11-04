using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardManager_BackEnd.Controllers;
using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Service.Boards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardManger_FrontEnd.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class BoardController : BaseController
    {
        private IBoardService _boardService;
     
        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }
        [Route("api/BoardController/getAllBoards")]
        [HttpGet]
        public List<Board> getAllBoards()
        {
            return _boardService.getAllBoard(_User.UserProfileId);
        }
        [Route("api/BoardController/addBoard")]
        [HttpPost]
        public IActionResult addBoard([FromBody] Board board)
        {
            board.UserProfileId = _User.UserProfileId;
            return Ok(_boardService.addBoard(board));
        }
    }
}