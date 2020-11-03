using Microsoft.EntityFrameworkCore;
using System;
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

           modelBuilder.Entity<ToDoModel>()
            .HasKey(c => c.Id);

            modelBuilder.Entity<UserData>()
            .HasMany(c => c.ToDoModels)
            .WithOne(c => c.UserData)
            .HasForeignKey(c => c.UserDataId)
            .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<ToDoModel>().HasData(
                new ToDoModel
                  {
                      Id =  1,
                      Title = "Test1",
                      UserDataId = 1,
                      CreateDate = DateTime.Now,
                      DeadLine = DateTime.Today.AddDays(1),
                      EndDate = new DateTime(),
                      Complete = false,
                  }, new ToDoModel
                  {
                      Id = 2,
                      Title = "Test2",
                      UserDataId = 1,
                      CreateDate = DateTime.Now,
                      DeadLine = DateTime.Today.AddDays(1),
                      EndDate = new DateTime(),
                      Complete = false,
                  }, new ToDoModel
                  {
                      Id = 3,
                      Title = "Test3",
                      UserDataId = 1,
                      CreateDate = DateTime.Now,
                      DeadLine = DateTime.Today.AddDays(1),
                      EndDate = new DateTime(),
                      Complete = false,
                  }, new ToDoModel
                  {
                      Id = 4,
                      Title = "Test1",
                      UserDataId = 2,
                      CreateDate = DateTime.Now,
                      DeadLine = DateTime.Today.AddDays(1),
                      EndDate = new DateTime(),
                      Complete = false,
                  },
                  new ToDoModel
                  {
                      Id = 5,
                      Title = "Test2",
                      UserDataId = 2,
                      CreateDate = DateTime.Now,
                      DeadLine = DateTime.Today.AddDays(1),
                      EndDate = new DateTime(),
                      Complete = false,
                  }, new ToDoModel
                  {
                      Id = 6,
                      Title = $"Test3",
                      UserDataId = 2,
                      CreateDate = DateTime.Now,
                      DeadLine = DateTime.Today.AddDays(1),
                      EndDate = new DateTime(),
                      Complete = false,
                  }
                );

            modelBuilder.Entity<UserData>().HasData(
                new UserData
                    {
                        Id = 1,
                    }, new UserData
                    {
                        Id = 2,
                    }
                );

        }

    }
}
