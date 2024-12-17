using Microsoft.EntityFrameworkCore;
using RazorToDOApp.Data;
using RazorToDOApp.Models;

namespace RazorToDOApp.Services
{
    public class ToDoService
    {
        private readonly ToDoDbContect _contect;
        public ToDoService(ToDoDbContect contect)
        {
            _contect= contect;
        }
        public async Task<List<ToDoItem>> GetToDoItems()
        {
            return await _contect.ToDoItems.ToListAsync();
        }
        public async Task AddNewToDo(string newTask)
        {
            if (!string.IsNullOrEmpty(newTask))
            {
                var newToDo = new ToDoItem { Task = newTask.Trim(), IsCompleted = false };
                _contect.ToDoItems.Add(newToDo);
                await _contect.SaveChangesAsync();
            }
        }
        public async Task DeleteTask(int id)
        {
                var item = await _contect.ToDoItems.FindAsync(id);
                _contect.ToDoItems.Remove(item);
                await _contect.SaveChangesAsync();
        }
    }
}
