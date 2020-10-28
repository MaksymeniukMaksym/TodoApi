using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface ITodoService
    {
        void AddTodo(string userId, string title);
        IEnumerable<ToDoModel> GetToDos(string userId);
        
        // Guid
        ToDoModel GetToDosById(int id);
        bool Remove(string userId, int id);
        bool Complete(string userId, int id);
        void UpdateTodo(string userId, int id, ToDoUpdate item);
      


    }
}
