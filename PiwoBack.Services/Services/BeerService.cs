using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PiwoBack.Data.DTOs;
using PiwoBack.Data.Models;
using PiwoBack.Repository.Interfaces;
using PiwoBack.Services.Interfaces;

namespace PiwoBack.Services.Services
{
    public class BeerService : IBeerService
    {
        private readonly IRepository<Beer> _beerRepository;
        private readonly IRepository<Brewery> _breweryRepository;
        private readonly IMapper _mapper;

        public BeerService(IRepository<Beer> beerRepository, IRepository<Brewery> breweryRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _breweryRepository = breweryRepository;
            _mapper = mapper;
        }

        public IEnumerable<BeerDto> GetAll()
        {
            var beers = _beerRepository.GetAll(x=> x.Brewery);
            return _mapper.Map<IEnumerable<Beer>, IEnumerable<BeerDto>>(beers);
        }

        public BeerDto GetBeer(int id)
        {
            var beer = _beerRepository.GetBy(x => x.Id == id, x => x.Brewery);

            if (beer == null)
            {
                return null;
            }

            _beerRepository.GetRelatedCollections(beer, x => x.Comments);
            return _mapper.Map<BeerDto>(beer);
        }
    }
}

