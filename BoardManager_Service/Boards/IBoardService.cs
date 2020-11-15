﻿using BoardManager_Data.BoardManagerContext.Models;
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
        ErrorObject deleteBoard(int id);
        ErrorObject addBoard(Board board);
        ErrorObject getListBoardDetail(int boardId, int userId);
        ErrorObject addBoardDetail(BoardDetail boardDetail);
        ErrorObject editBoardDetail(BoardDetail boardDetail);
        ErrorObject deleteBoardDetail(BoardDetail boardDetail);
    }
}
