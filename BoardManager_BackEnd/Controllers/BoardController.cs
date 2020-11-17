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
        [AllowAnonymous]
        [Route("api/BoardController/getAllBoards")]
        [HttpGet]
        public List<Board> getAllBoards()
        {
            return _boardService.getAllBoard(_User.Id);
        }
        [AllowAnonymous]
        [Route("api/BoardController/addBoard")]
        [HttpPost]
        public IActionResult addBoard([FromBody] Board board)
        {
            board.UserProfileId = _User.Id;
           
            return Ok(_boardService.addBoard(board));
        }
        [Route("api/BoardController/delete/{id}")]
        [AllowAnonymous]

        public IActionResult deleteBoard( int id)
        {
           
            return Ok(_boardService.deleteBoard(id));
        }
        [Route("api/BoardController/edit")]
        [AllowAnonymous]

        public IActionResult editBoard(Board board)
        {

            return Ok(_boardService.editBoard(board));
        }
        [Route("api/BoardController/getListBoardDetail/{boardId}")]
        [AllowAnonymous]
        public IActionResult getListBoardDetail(int boardId)
        {
            return Ok(_boardService.getListBoardDetail(boardId,_User.Id));
        }
        [Route("api/BoardController/addBoardDetail")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddBoardDetail([FromBody] BoardDetail boardDetail)
        {
            return Ok(_boardService.addBoardDetail(boardDetail));

        }
        [Route("api/BoardController/editBoardDetail")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult EditBoardDetail([FromBody] BoardDetail boardDetail)
        {
            return Ok(_boardService.editBoardDetail(boardDetail));

        }
        [Route("api/BoardController/deleteBoardDetail")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult DeleteBoardDetail([FromBody] BoardDetail boardDetail)
        {
            return Ok(_boardService.deleteBoardDetail(boardDetail));

        }
    }
}