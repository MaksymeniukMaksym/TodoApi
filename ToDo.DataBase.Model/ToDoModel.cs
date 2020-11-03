using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDo.DataBase.Model
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime EndDate { get; set; }
        public bool Complete { get; set; }

        public int UserDataId { get; set; }
        public UserData UserData { get; set; }

    }
}
