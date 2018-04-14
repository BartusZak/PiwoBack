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
    public class BreweryService:IBreweryService
    {
        private readonly IRepository<Brewery> _breweryRepository;
        private readonly IMapper _mapper;

        public BreweryService(IRepository<Brewery> breweryRepository, IMapper mapper)
        {
            _breweryRepository = breweryRepository;
            _mapper = mapper;
        }

        public IEnumerable<BreweryDto> GetAll()
        {
            var breweries = _breweryRepository.GetAll(bg => bg.BrewingGroup);
            return _mapper.Map<IEnumerable<Brewery>, IEnumerable<BreweryDto>>(breweries);
        }

        public BreweryDto GetBrewery(int id)
        {
            var brewery = _breweryRepository.GetBy(x => x.Id == id, bg => bg.BrewingGroup);
            
            if (brewery == null)
            {
                return null;
            }

            _breweryRepository.GetRelatedCollections(brewery, x => x.Beers);
            return _mapper.Map<BreweryDto>(brewery);
        }
    }
}
