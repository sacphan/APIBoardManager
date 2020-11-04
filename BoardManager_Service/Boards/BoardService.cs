using System;
using System.Collections.Generic;
using System.Text;
using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Data.BoardManagerContext;
using System.Linq;
using BoardManager_Model;


namespace BoardManager_Service.Boards
{
	public class BoardService : IBoardService
	{
		public List<Board> getAllBoard(int UserId)
		{
			var listBoard = new List<Board>();
			try
			{
				using (var db = new BoardManagerContext())
				{
					listBoard = db.Board.Where(e=>e.UserProfileId==UserId).ToList();
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return listBoard;
		}
		public  ErrorObject addBoard(Board board)
		{
			var error = new ErrorObject(Error.SUCCESS);
			try
			{
				using (var db = new BoardManagerContext())
				{
					db.Board.Add(board);
					db.SaveChanges();
					error.SetData(board);
				}
			}
			catch (Exception ex)
			{

				 error.Failed(ex.Message);
			}
			return error;
		}
	
		public ErrorObject deleteBoard(Board board)
		{
			var error = new ErrorObject(Error.SUCCESS);
			try
			{
				using (var db = new BoardManagerContext())
				{
					var boardremove = db.Board.FirstOrDefault(b=>b.Id==board.Id);
					db.Board.Remove(boardremove);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				error.Failed(ex.Message);
			}
			return error;
		}
		public ErrorObject editBoard(Board board)
		{
			var error = new ErrorObject(Error.SUCCESS);
			try
			{
				using (var db = new BoardManagerContext())
				{
					var boardEdit = db.Board.FirstOrDefault(b => b.Id == board.Id);
					boardEdit.Name = board.Name;
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				error.Failed(ex.Message);
			}
			return error;
		}
	}
}
