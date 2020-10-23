using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public interface IToDoService 
    {
        IEnumerable<ToDoModel> GetToDos();

        // Guid
        ToDoModel GetToDosById(int id);
        void UpdateTodo(int id, ToDoUpdate item);
        void AddTodo(string title);
        bool Remove(int id);
        bool Complete(int id);


    }

    public class ToDoService : IToDoService
    {
        private List<ToDoModel> _toDos;

        public ToDoService()
        {
            _toDos = GetDefaultTDos();
        }


        public void AddTodo(string title)
        {
            int Id = _toDos[_toDos.Count - 1].Id + 1;
            var newTodo = new ToDoModel
            {
                Id = Id,
                Title = $"{title}{Id}",
                CreateDate = DateTime.Now,
                DeadLine = DateTime.Now,
                Complete = false,
            };
            _toDos.Add(newTodo);
        }

        public IEnumerable<ToDoModel> GetToDos()
        {
            return _toDos;
        }

        public ToDoModel GetToDosById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            foreach (ToDoModel todo in _toDos)
            {
                if (todo.Id == id)
                {
                    _toDos.Remove(todo);
                    Console.WriteLine(todo);
                    return true;

                }
            }
            return false;
        }
        public bool Complete(int id)
        {
            foreach (ToDoModel todo in _toDos)
            {
                if (todo.Id == id)
                {
                    todo.Complete = true;
                    Console.WriteLine(todo);
                    return true;

                }
            }
            return false;
        }

        public void UpdateTodo(int id, ToDoUpdate item)
        {
            foreach (ToDoModel todo in _toDos)
            {
                if (todo.Id == id)
                {
                    if (!String.IsNullOrEmpty(item.DeadLine))
                    {
                        todo.DeadLine = DateTime.Parse(item.DeadLine);

                    }
                    if (!String.IsNullOrEmpty(item.EndDate))
                    {
                        todo.EndDate = DateTime.Parse(item.EndDate);

                    }
                    todo.Title = item.Title;
                }
            }
        }

        private List<ToDoModel> GetDefaultTDos()
        {
            var toDos = new List<ToDoModel>();

            for (int i = 0; i < 10; i++)
            {
                toDos.Add(new ToDoModel
                {
                    Id = i+1,
                    Title = $"Test{i+1}",
                    CreateDate  = DateTime.Now,
                    DeadLine = DateTime.Today.AddDays(1),
                    EndDate = new DateTime(),
                    Complete = false,
                });
            }

            return toDos;
        }
    }
}
