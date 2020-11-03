using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.DataBase;
using ToDoApi.Interfaces;
using ToDoApi.Models;
using ToDo.DataBase.Repository.Abstraction;
using AutoMapper;
using ToDo.DataBase.Model;
using ToDoApi.AutoMapper.Profilers;

namespace ToDoApi.Services
{

    public class ToDoService : ITodoService
    {
        private List<UserDataViewModel> _toDosData;
        private readonly IUserDataRepository _userDataRepository;
        private readonly IToDoRepository _toDoRepository;

        private Mapper _mapper;
        public ToDoService(IUserDataRepository repository, IToDoRepository toDoRepository) 
        {

            var mapperConfig = new MapperConfiguration((configuration) => {
                configuration.AddProfile(new UserDataProfile());
                configuration.AddProfile(new ToDoModelProfile());

            });
            _mapper = new Mapper(mapperConfig);

          
            _userDataRepository = repository;
            _toDoRepository = toDoRepository;

            _toDosData = GetDefaultTDos();
        }


        public void AddTodo(int userId,string title)
        {

            var newTodo = new ToDoViewModel
            {
                Title = $"{title}",
                CreateDate = DateTime.Now,
                DeadLine = DateTime.Now,
                Complete = false,
                UserDataId = userId
            };
            _toDoRepository.Add( _mapper.Map<ToDoViewModel, ToDoModel>(newTodo) );
        }

        public IEnumerable<ToDoViewModel> GetToDos(int userId)
        {
            var user = _toDosData.FirstOrDefault(user => user.Id == userId);

            return user.ToDoModels;
        }

        public bool Remove(int userId ,int id)
        {
             return _toDoRepository.Remove(id);
        }

        public ToDoViewModel Complete(int id)
        {

            var todo = _toDoRepository.GetById(id);
            todo.Complete = true;
           _toDoRepository.Update(todo);

            return _mapper.Map<ToDoModel,ToDoViewModel > (todo);
        }

        public void UpdateTodo(int id, ToDoUpdate item)
        {

            var todo = _toDoRepository.GetById(id);

            todo.Title = item.Title;
            todo.DeadLine = Convert.ToDateTime(item.DeadLine);
            todo.EndDate = Convert.ToDateTime(item.EndDate);
            _toDoRepository.Update(todo);

        }

        private List<UserDataViewModel> GetDefaultTDos()
        {
          
            var userEntity = _userDataRepository.GetAll().ToList();
            return _mapper.Map< List<UserData>, List<UserDataViewModel>>(userEntity);
        }

    }
}
