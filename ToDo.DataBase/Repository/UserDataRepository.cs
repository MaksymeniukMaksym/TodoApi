using System;
using System.Collections.Generic;
using System.Text;
using ToDo.DataBase.Model;
using ToDo.DataBase.Repository.Abstraction;

namespace ToDo.DataBase.Repository
{
   
    public class UserDataRepository : RepositoryBase<UserData>, IUserDataRepository
    {
        public UserDataRepository(ToDoContext context) : base(
            context) { }

    }
}
