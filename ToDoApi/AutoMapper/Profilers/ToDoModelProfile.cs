using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.DataBase.Model;
using ToDoApi.Models;

namespace ToDoApi.AutoMapper.Profilers
{
    public class ToDoModelProfile: Profile
    {
        public ToDoModelProfile()
        {
            CreateMap<ToDoModel, ToDoViewModel>()
                .ForMember("Id", opt => opt.MapFrom(c => c.Id))
                .ForMember("Title", opt => opt.MapFrom(c => c.Title))
                .ForMember("CreateDate", opt => opt.MapFrom(c => c.CreateDate))
                .ForMember("DeadLine", opt => opt.MapFrom(c => c.DeadLine))
                .ForMember("EndDate", opt => opt.MapFrom(c => c.EndDate))
                .ForMember("Complete", opt => opt.MapFrom(c => c.Complete))
                .ReverseMap();             
        }
    }
}
