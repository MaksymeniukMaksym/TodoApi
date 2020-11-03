using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.DataBase.Repository.Abstraction
{
    public interface IRepository<TEntyti>
    {
        IEnumerable<TEntyti> GetAll();
        void Add(TEntyti element);
        bool Remove(int id);
    }
}
