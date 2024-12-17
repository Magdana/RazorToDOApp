using BoardManagement.Models;
using BoardManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardManagement.Pages
{
    public class ManageBoardsPageModel : PageModel
    {
        private readonly BoardService _boardService;
        private readonly ToDoService _todoService;
        public ManageBoardsPageModel(BoardService boardService, ToDoService todoService)
        {
            _boardService = boardService;
            _todoService = todoService;
        }
        public List<Board> Boards { get; set; }
        public List<ToDoItem> ToDoItems { get; set; }
        [BindProperty]
        public string NewBoardName { get; set; }
        [BindProperty]
        public string NewTask { get; set; }
        [BindProperty]
        public int? SelectedBoardId { get; set; }
        public async Task OnGet()
        {
            Boards = await _boardService.GetBoards();
            ToDoItems = await _todoService.GetToDoItems();
        }
        public async Task<IActionResult> OnPostAddBoardAsync()
        {
            if (!string.IsNullOrEmpty(NewBoardName))
            {
                var board = new Board { Name = NewBoardName };
                await _boardService.AddNewBoard(board);
            }
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostAddTaskAsync()
        {
            var todo = new ToDoItem { TodoName = NewTask, BoardId = SelectedBoardId };
            await _todoService.AddNewToDo(todo);
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostTaskCompletedAsync(int id)
        {
            var todoItem = await _todoService.GetToDoById(id);

            todoItem.IsCompleted = !todoItem.IsCompleted;
            await _todoService.UpdateToDo(todoItem);

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _todoService.DeleteToDo(id);
            return RedirectToPage();
        }

    }
}
