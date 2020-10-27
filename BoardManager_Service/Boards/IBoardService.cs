using BoardManager_Data.BoardManagerContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardManager_Service.Boards
{
    public interface IBoardService
    {
        List<Board> getAllBoard();
    }
}
