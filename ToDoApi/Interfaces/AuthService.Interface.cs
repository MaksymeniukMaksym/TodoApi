using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
   public interface IAuthService
    {
        LoginResponse Login(LoginData data);
        void Register(RegisterData data);
    }
}
