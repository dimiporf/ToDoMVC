using System;
using System.Collections.Generic;
using System.Linq;
using ToDoMVC.Models;
using ToDoMVC.Service.IService;

namespace ToDoMVC.Service
{
    public class InMemoryToDoRepository : IToDoRepository
    {
        private readonly List<ToDo> _todos;
        private int _nextId = 1;

        public InMemoryToDoRepository()
        {
            _todos = new List<ToDo>();
        }

        public IEnumerable<ToDo> GetAllToDos()
        {
            return _todos;
        }

        public ToDo GetToDoById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }

        public void AddToDo(ToDo todo)
        {
            todo.Id = _nextId++;
            _todos.Add(todo);
        }

        public void UpdateToDo(ToDo toDo)
        {
            var existingToDo = _todos.FirstOrDefault(t => t.Id == toDo.Id);
            if (existingToDo != null)
            {
                existingToDo.Title = toDo.Title;
                existingToDo.IsCompleted = toDo.IsCompleted;
            }
            else
            {
                throw new ArgumentException($"ToDo with ID {toDo.Id} not found.");
            }
        }

        public void UpdateToDoCompletionStatus(int todoId, bool isCompleted)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == todoId);
            if (todo != null)
            {
                todo.IsCompleted = isCompleted;
            }
        }

        public void DeleteToDo(int id)
        {
            var todoToRemove = GetToDoById(id);
            if (todoToRemove != null)
            {
                _todos.Remove(todoToRemove);
            }
        }

        public void SetToDoCompleted(int id, bool isCompleted)
        {
            var toDoToUpdate = _todos.FirstOrDefault(t => t.Id == id);
            if (toDoToUpdate != null)
            {
                toDoToUpdate.IsCompleted = isCompleted;
            }
            else
            {
                throw new ArgumentException($"ToDo with ID {id} not found.");
            }
        }
    }
}
