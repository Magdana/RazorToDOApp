using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorToDOApp.Data;
using RazorToDOApp.Models;
using RazorToDOApp.Services;

namespace RazorToDOApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ToDoService _service;

        public IndexModel(ILogger<IndexModel> logger, ToDoDbContect toDoDbContect, ToDoService service)
        {
            _logger = logger;
            _service = service;
        }


        public List<ToDoItem> ToDoItems { get; set; }
        [BindProperty]
        public string NewTask { get; set; }
        public async Task OnGet()
        {
            ToDoItems = await _service.GetToDoItems();
        }
        public async Task<IActionResult> OnPost()
        {
            await _service.AddNewToDo(NewTask);
            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _service.DeleteTask(id);
            return RedirectToPage();
        }
    }
}
