using System;
using System.Collections.Generic;
using System.Text;
using BoardManager_Data.BoardManagerContext.Models;
using BoardManager_Data.BoardManagerContext;
using System.Linq;
using BoardManager_Model;
using Microsoft.EntityFrameworkCore;

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
	
		public ErrorObject deleteBoard(int id)
		{
			var error = new ErrorObject(Error.SUCCESS);
			try
			{
				using (var db = new BoardManagerContext())
				{
					var boardremove = db.Board.FirstOrDefault(b=>b.Id== id);
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
					error.SetData(boardEdit);
				}
			}
			catch (Exception ex)
			{

				error.Failed(ex.Message);
			}
			return error;
		}
		public ErrorObject getListBoardDetail(int boardId,int userId)
		{
			var error = new ErrorObject(Error.SUCCESS);
			try
			{
				using (var db = new BoardManagerContext())
				{
					var board = db.Board.FirstOrDefault(b => b.Id == boardId && b.UserProfileId == userId);
					var listCloumn_mapping_board = db.ColumnMappingBoard.Where(m => m.BoardId == board.Id).ToList().Select(m=>m.Id).ToList();
					var listColumnBoard = db.ColumnBoard.Where(b => listCloumn_mapping_board.Contains(b.Id)).Include(c=>c.BoardDetail).ToList();			
					error.SetData(listColumnBoard);
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
