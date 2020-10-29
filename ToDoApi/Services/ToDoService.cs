using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.DataBase;
using ToDoApi.Interfaces;
using ToDoApi.Models;
using ToDo.DataBase.Repository.Abstraction;

namespace ToDoApi.Services
{

    public class ToDoService: ITodoService
    {
        private List<UserData> _toDosData;
        private readonly IDataUserRepository _toDoContext;
        public ToDoService(IToDoRepository repository)
        {
            _toDosData = GetDefaultTDos();
            _toDoContext = context;

        }


        public void AddTodo(string userId,string title)
        {
            var user = GetUserTodos(userId);
            var toDos = user.todos;

            int Id = toDos[toDos.Count - 1].Id + 1;
            var newTodo = new ToDoModel
            {
                Id = Id,
                Title = $"{title}{Id}",
                CreateDate = DateTime.Now,
                DeadLine = DateTime.Now,
                Complete = false,
            };
            toDos.Add(newTodo);
            user.todos = toDos;
            AddUserTodos(user);
        }

        public IEnumerable<ToDoModel> GetToDos(string userId)
        {
            var user = GetUserTodos(userId);

            return user.todos;
        }

        public ToDoModel GetToDosById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string userId ,int id)
        {
            var user = GetUserTodos(userId);
            var todos = user.todos;
            foreach (ToDoModel todo in todos)
            {
                if (todo.Id == id)
                {
                    todos.Remove(todo);
                    user.todos = todos;
                    UpdateUserTodos(user);
                    return true;

                }
            }
            return false;
        }
        public bool Complete(string userId,int id)
        {
            var user = GetUserTodos(userId);
            var todos = user.todos;
            foreach (ToDoModel todo in todos)
            {
                if (todo.Id == id)
                {
                    todo.Complete = true;
                    user.todos = todos;
                    UpdateUserTodos(user);
                    return true;

                }
            }
            return false;
        }

        public void UpdateTodo(string userId,int id, ToDoUpdate item)
        {
            var user = GetUserTodos(userId);
            var todos = user.todos;
            foreach (ToDoModel todo in todos)
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
            user.todos = todos;
            UpdateUserTodos(user);
        }

        private List<UserData> GetDefaultTDos()
        {
            var userData = new List<UserData>();
            for(int j = 0; j <= 1; j++)
            {
                var toDos = new List<ToDoModel>();

                for (int i = 0; i < 10; i++)
                {
                    toDos.Add(new ToDoModel
                    {
                        Id = i + 1,
                        Title = $"Test{i + 1}",
                        CreateDate = DateTime.Now,
                        DeadLine = DateTime.Today.AddDays(1),
                        EndDate = new DateTime(),
                        Complete = false,
                    });
                }
                userData.Add(
                    new UserData
                    {
                        id = $"test{j}@test.com",
                        todos = toDos

                    });
            }
           

            return userData;
        }
        private UserData GetUserTodos(string id)
        {
            var user =  _toDosData.FirstOrDefault( user => user.id == id);
            return user;
        }
        private void UpdateUserTodos(UserData userData)
        {
            for (int i = 0; i < _toDosData.Count ; i++)
            {
                if (_toDosData[i].id == userData.id)
                {
                    _toDosData[i] = userData;
                    return;
                }
            }
        }
        private void AddUserTodos(UserData userData)
        {
            _toDosData.Add(userData);
        }
    }
}
