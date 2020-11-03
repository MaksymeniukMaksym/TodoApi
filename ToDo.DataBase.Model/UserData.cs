using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDo.DataBase.Model
{
    public class UserData
    {
        public int Id { get; set; }
        public List<ToDoModel> ToDoModels { get; set; }
    }
}
