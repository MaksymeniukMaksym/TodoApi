using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ToDo.DataBase
{
    public class ToDoContextFactory : IDesignTimeDbContextFactory<ToDoContext>
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ToDo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public ToDoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ToDoContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new ToDoContext(optionsBuilder.Options);
        }
    }
}
