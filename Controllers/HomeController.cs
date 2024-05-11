using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoWebClient.Models;
using ToDoWebClient.Services;

namespace ToDoWebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITodoService _todoService;
        public HomeController(ILogger<HomeController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Todo(int? id = null)
        {
            var viewModel = new List<TodoItem>();
            if (id == null || id.Value <= 0)
                viewModel = await _todoService.GetAll();
            else
            {
                var todo = await _todoService.GetById(id.Value);
                viewModel.Add(todo);
            }
            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
