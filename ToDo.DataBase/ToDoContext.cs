using Microsoft.EntityFrameworkCore;
using ToDo.DataBase.Model;

namespace ToDo.DataBase
{
    public class ToDoContext: DbContext
    {
        public DbSet<Task> Tasks;

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
    }
}
