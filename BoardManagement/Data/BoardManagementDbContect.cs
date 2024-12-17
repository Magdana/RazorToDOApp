using BoardManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardManagement.Data
{
    public class BoardManagementDbContect: DbContext
    {
        public BoardManagementDbContect(DbContextOptions<BoardManagementDbContect> options) : base(options) { }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Board> Boards { get; set; }
    }
}
