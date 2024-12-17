using BoardManagement.Data;
using BoardManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace BoardManagement.Services
{
    public class ToDoService
    {
        private readonly BoardManagementDbContect _contect;
        public ToDoService(BoardManagementDbContect contect)
        {
            _contect = contect;
        }
        public async Task<List<ToDoItem>> GetToDoItems()
        {
            return await _contect.ToDoItems.ToListAsync();
        }
        public async Task AddNewToDo(ToDoItem Todo)
        {

            _contect.ToDoItems.Add(Todo);
            await _contect.SaveChangesAsync();

        }
        public async Task DeleteToDo(int id)
        {
            var item = await _contect.ToDoItems.FirstOrDefaultAsync(x=> x.Id==id);
            if (item != null)
            {
                _contect.ToDoItems.Remove(item);
                await _contect.SaveChangesAsync();
            }

        }
        public async Task<ToDoItem> GetToDoById(int id)
        {
            var todo = await _contect.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
            return todo;
        }
        public async Task UpdateToDo(ToDoItem todo)
        {
            _contect.ToDoItems.Update(todo);
            await _contect.SaveChangesAsync();
        }
    }
}
