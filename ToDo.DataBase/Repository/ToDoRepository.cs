using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.DataBase.Model;
using ToDo.DataBase.Repository.Abstraction;

namespace ToDo.DataBase.Repository
{

    public class ToDoRepository: RepositoryBase<ToDoModel>, IToDoRepository
    {
        public ToDoRepository(ToDoContext context) : base(context) { }

    }
}
