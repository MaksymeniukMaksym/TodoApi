using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.DataBase.Model;
using ToDo.DataBase.Repository.Abstraction;

namespace ToDo.DataBase.Repository
{

    public class ToDoRepository: RepositoryBase<ToDoModel>, IToDoRepository
    {
        public ToDoRepository(ToDoContext context) : base(context) { }

        public new bool Remove(int id)
        {
            ToDoModel model = _entity.Where(o => o.Id == id)
            .FirstOrDefault();
            _entity.Remove(model);
            Save();
            return true;
        }
        public ToDoModel GetById(int id)
        {
            ToDoModel model = _entity.Where(o => o.Id == id)
            .FirstOrDefault();
            return model;
        }
        public void Update(ToDoModel element)
        {
            var entity = _entity.Where(o => o.Id == element.Id)
            .FirstOrDefault();
            entity = element;
            _entity.Update(entity);
            Save();
        }

    }
}
