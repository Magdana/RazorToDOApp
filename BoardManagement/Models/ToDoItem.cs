using BoardManagement.Models;

namespace BoardManagement.Models
{
        public class ToDoItem
        {
            public int Id { get; set; }
            public string TodoName { get; set; }
            public bool IsCompleted { get; set; }
            public int? BoardId { get; set; }
            public Board? Board { get; set; }
        }
}
