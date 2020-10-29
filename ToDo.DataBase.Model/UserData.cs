using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDo.DataBase.Model
{
    public class UserData
    {
        public int Id { get; set; }
        public ICollection<ToDoModel> Todos { get; set; }
    }
}
