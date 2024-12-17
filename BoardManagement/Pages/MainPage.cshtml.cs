using BoardManagement.Models;
using BoardManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardManagement.Pages
{
    public class MainPageModel : PageModel
    {
        private readonly BoardService _boardService;
        public MainPageModel(BoardService boardService)
        {
            _boardService = boardService;
        }
        public List<Board> Boards { get; set; }
        public async Task OnGet()
        {
            Boards = await _boardService.GetBoards();
        }
    }
}
