using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
    public class UserData
    {
       public string id { get; set; }
       public List<ToDoModel> todos { get; set; }
    }
}
