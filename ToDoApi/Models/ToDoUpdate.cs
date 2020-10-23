using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
    public class ToDoUpdate
    {
        public string Title { get; set; }
        public string DeadLine { get; set; }
        public string EndDate { get; set; }
    }
}
