using AutoMapper;
using PiwoBack.Data.DTOs;
using PiwoBack.Data.Models;
using PiwoBack.Repository.Interfaces;
using PiwoBack.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwoBack.Services.Services
{
    public class BrewingGroupService:IBrewingGroupService
    {
        private readonly IRepository<BrewingGroup> _brewingGroupRepository;
        private readonly IRepository<Brewery> _brewery;
        private readonly IMapper _mapper;
           
        public BrewingGroupService(IRepository<BrewingGroup> brewingGroupRepository, IMapper mapper, IRepository<Brewery> brewery)
        {
            _brewingGroupRepository = brewingGroupRepository;
            _brewery = brewery;
            _mapper = mapper;
        }

        public IEnumerable<BrewingGroupDto> GetAll()
        {
            var brewingGroups = _brewingGroupRepository.GetAll();
            return _mapper.Map<IEnumerable<BrewingGroup>, IEnumerable<BrewingGroupDto>>(brewingGroups);
        }

        public BrewingGroupDto GetBrewingGroup(int id)
        {
            var brewingGroup = _brewingGroupRepository.GetBy(x => x.Id == id);

            if (brewingGroup == null)
            {
                return null;
            }

            _brewingGroupRepository.GetRelatedCollections(brewingGroup, x => x.Breweries);
            return _mapper.Map<BrewingGroupDto>(brewingGroup);
        }
    }
}
