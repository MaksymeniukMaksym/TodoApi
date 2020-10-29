using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo.DataBase.Repository.Abstraction
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity: class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _entity;

        public RepositoryBase(DbContext context)
        {
            _dbContext = context;
            _entity = _dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entity.ToList();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
