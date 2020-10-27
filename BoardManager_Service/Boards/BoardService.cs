using System;
using System.Collections.Generic;
using System.Text;
using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Data.BoardManagerContext;
using System.Linq;
namespace BoardManager_Service.Boards
{
    public class BoardService: IBoardService
    {
        public List<Board> getAllBoard()
        {
			var listBoard = new List<Board>();
			try
			{
				using (var db =new BoardManagerContext())
				{
					listBoard = db.Board.ToList();
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return listBoard;
        }
    }
}
