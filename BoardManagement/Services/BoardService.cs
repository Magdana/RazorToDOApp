using BoardManagement.Data;
using BoardManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardManagement.Services
{
    public class BoardService
    {
        private readonly BoardManagementDbContect _contect;
        public BoardService(BoardManagementDbContect contect)
        {
            _contect = contect;
        }
        public async Task<List<Board>> GetBoards()
        {
            return await _contect.Boards.ToListAsync();
        }
        public async Task AddNewBoard(Board board)
        {
            _contect.Boards.Add(board);
            await _contect.SaveChangesAsync();
        }
        public async Task DeleteBoard(int id)
        {
            var item = await _contect.Boards.FindAsync(id);
            _contect.Boards.Remove(item);
            await _contect.SaveChangesAsync();
        }
        public async Task<Board> GetBoardById(int id)
        {
            var board = await _contect.Boards.FirstOrDefaultAsync(x => x.Id == id);
            return board;
        }
        public async Task UpdateBoard(Board board)
        {
            _contect.Boards.Update(board);
            await _contect.SaveChangesAsync();
        }
    }
}
