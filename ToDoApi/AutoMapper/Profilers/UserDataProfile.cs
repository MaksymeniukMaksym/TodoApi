using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.DataBase.Model;
using ToDoApi.Models;

namespace ToDoApi.AutoMapper.Profilers
{
    public class UserDataProfile : Profile
    {
        public UserDataProfile()
        {
            CreateMap<UserData, UserDataViewModel>()
                .ForMember("Id", opt => opt.MapFrom(c => c.Id))
                .ForMember("ToDoModels", opt => opt.MapFrom(c => c.ToDoModels));
             
        }
    }
}
