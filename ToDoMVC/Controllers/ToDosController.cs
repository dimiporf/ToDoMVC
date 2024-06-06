using Microsoft.AspNetCore.Mvc;
using ToDoMVC.Service.IService;
using ToDoMVC.Models;

namespace ToDoMVC.Controllers
{
    public class ToDosController : Controller
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDosController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public IActionResult Index()
        {
            var toDos = _toDoRepository.GetAllToDos();
            return View(toDos);
        }

        [HttpPost]
        public IActionResult AddToDo(string toDoTitle)
        {
            if (!string.IsNullOrEmpty(toDoTitle))
            {
                _toDoRepository.AddToDo(new ToDo { Title = toDoTitle });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteToDo(int toDoId)
        {
            _toDoRepository.DeleteToDo(toDoId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SetToDoCompleted(int toDoId, bool isCompleted)
        {
            _toDoRepository.SetToDoCompleted(toDoId, isCompleted);
            return RedirectToAction("Index");
        }
    }
}
