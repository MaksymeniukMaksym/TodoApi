﻿using System;
using System.Collections.Generic;
using System.Text;
using ToDo.DataBase.Model;

namespace ToDo.DataBase.Repository.Abstraction
{
    public interface IToDoRepository: IRepository<ToDoModel>
    {
        public ToDoModel GetById(int id);

        public void Update(ToDoModel element);
    }
}
