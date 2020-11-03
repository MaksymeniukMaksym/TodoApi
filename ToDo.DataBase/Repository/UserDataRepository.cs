using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.DataBase.Model;
using ToDo.DataBase.Repository.Abstraction;

namespace ToDo.DataBase.Repository
{
   
    public class UserDataRepository : RepositoryBase<UserData>, IUserDataRepository
    {
        public UserDataRepository(ToDoContext context) : base(context) { }


        public UserData GetById(int Id)
        {
            return _entity.FirstOrDefault(x => x.Id == Id);
        }

        public new IEnumerable<UserData> GetAll()
        {
            return _entity.Include(e => e.ToDoModels).ToList();
        }
    }

}
