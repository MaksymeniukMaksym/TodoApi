using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface ITodoService
    {
        void AddTodo(int userId, string title);
        IEnumerable<ToDoViewModel> GetToDos(int userId);
        bool Remove(int userId, int id);
        ToDoViewModel Complete(int id);
        void UpdateTodo( int id, ToDoUpdate item);
      
       

    }
}
