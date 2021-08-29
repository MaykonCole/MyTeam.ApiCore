using AutoMapper;
using MyTeam.Core.Models;
using MyTeam.Core.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeam.WebApiCore.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UpdateUserViewModel>().ReverseMap();
            CreateMap<User, AppUserViewModel>().ReverseMap();
        }
    }
}
