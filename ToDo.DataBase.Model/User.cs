
using Microsoft.AspNetCore.Identity;

namespace ToDo.DataBase.Model
{
    public class User : IdentityUser
    {
        public string Surname { get; set; }
    }
}
