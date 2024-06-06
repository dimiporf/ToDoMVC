using System.Collections.Generic;
using ToDoMVC.Models;

namespace ToDoMVC.Service.IService
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetAllToDos();
        ToDo GetToDoById(int id);
        void AddToDo(ToDo todo);
        void UpdateToDo(ToDo todo);
        void DeleteToDo(int id);
        void SetToDoCompleted(int id, bool isCompleted);
    }
}
