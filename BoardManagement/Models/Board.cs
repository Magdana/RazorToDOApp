namespace BoardManagement.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToDoItem> ToDoItems { get; set; } = new();
    }
}
