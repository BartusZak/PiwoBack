using AutoMapper;
using PiwoBack.Data.DTOs;
using PiwoBack.Data.Models;
using PiwoBack.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwoBack.Services.MappingProfile
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Beer, BeerDto>();
            CreateMap<Beer, BeerChildDto>();

            CreateMap<Brewery, BreweryDto>();
            CreateMap<Brewery, BreweryChildDto>();

            CreateMap<BrewingGroup, BrewingGroupDto>();

            CreateMap<Comment, CommentDto>();

            CreateMap<User, RegisterDto>();
            CreateMap<RegisterViewModel, User>();
            CreateMap<User, LoginDto>();
        }
    }
}
