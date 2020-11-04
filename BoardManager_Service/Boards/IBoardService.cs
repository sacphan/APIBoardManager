using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardManager_Service.Boards
{
    public interface IBoardService
    {
        List<Board> getAllBoard(int UserId);
        ErrorObject editBoard(Board board);
        ErrorObject deleteBoard(Board board);
        ErrorObject addBoard(Board board);
    }
}
