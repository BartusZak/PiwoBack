using AutoMapper;
using PiwoBack.Data.DTOs;
using PiwoBack.Data.Models;
using PiwoBack.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwoBack.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Beer, BeerDto>().ReverseMap();
            CreateMap<Beer, BeerChildDto>().ReverseMap();
            CreateMap<BeerDto, BeerViewModel>().ReverseMap();
            CreateMap<BeerChildDto, BeerViewModel>().ReverseMap();
            CreateMap<Beer, BeerViewModel>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Brewery, BreweryDto>().ReverseMap();
            CreateMap<Brewery, BreweryChildDto>().ReverseMap();
            CreateMap<Brewery, BreweryViewModel>().ReverseMap();
            CreateMap<BrewingGroup, BrewingGroupDto>().ReverseMap();
            CreateMap<BrewingGroup, BrewingGroupChildDto>().ReverseMap();
            
        }
    }
}
