using Microsoft.EntityFrameworkCore;
using RazorToDOApp.Models;

namespace RazorToDOApp.Data
{
    public class ToDoDbContect: DbContext
    {
        public ToDoDbContect(DbContextOptions<ToDoDbContect> options) : base(options) { }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
