using Microsoft.EntityFrameworkCore;
using ToDo.DataBase.Model;

namespace ToDo.DataBase
{
    public class ToDoContext : DbContext
    {
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<ToDoModel> Todos { get; set; }


        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>()
            .HasKey(c => c.Id);

            modelBuilder.Entity<UserData>()
           .HasMany(c => c.Todos)
           .WithOne()
           .HasForeignKey(c => c.UserDataId)
           .HasPrincipalKey(c => c.Id);
           

        }

    }
}
