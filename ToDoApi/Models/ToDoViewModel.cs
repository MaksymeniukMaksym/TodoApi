using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
    public class ToDoViewModel
    {
       public int Id { get; set; }
       public string Title { get; set; }
       public DateTime CreateDate { get; set; }
       public DateTime DeadLine { get; set; }
       public DateTime EndDate { get; set; }
       public bool Complete { get; set; }
       public int UserDataId { get; set; }

    }
}
