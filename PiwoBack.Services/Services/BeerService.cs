using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AutoMapper;
using PiwoBack.Data.DTOs;
using PiwoBack.Data.Models;
using PiwoBack.Data.ViewModels;
using PiwoBack.Repository.Interfaces;
using PiwoBack.Services.Interfaces;

namespace PiwoBack.Services.Services
{
    public class BeerService : IBeerService
    {
        private readonly IRepository<Beer> _beerRepository;
        private readonly IRepository<Brewery> _breweryRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public BeerService(IRepository<Beer> beerRepository, IRepository<Brewery> breweryRepository, IRepository<User> userRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _breweryRepository = breweryRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<BeerDto> GetAll()
        {
            var beers = _beerRepository.GetAll(x=> x.Brewery, c => c.Comments);
            return _mapper.Map<IEnumerable<BeerDto>>(beers);
        }

        public BeerDto GetBeer(int id)
        {
            var beer = _beerRepository.GetBy(x => x.Id == id, x => x.Brewery);

            if (beer == null)
            {
                return null;
            }

            _beerRepository.GetRelatedCollectionsWithObject(beer, x => x.Comments, a => a.User);
            return _mapper.Map<BeerDto>(beer);
        }

        public ResultDto<BeerDto> Insert(BeerViewModel beerViewModel)
        {
            var result = new ResultDto<BeerDto>();

            var brewery = _breweryRepository.GetBy(x => x.Id == beerViewModel.BreweryId);
            if (brewery == null)
            {
                result.Errors.Add("Nie istnieje taki browar");
                return result;
            }
            if(_beerRepository.Exist(x => x.Name == beerViewModel.Name && x.Brewery.Id == beerViewModel.BreweryId))
            {
                result.Errors.Add("Piwo o podanej nazwie jest już dodane do browaru");
                return result;
            }
           
            var beer = _mapper.Map<Beer>(beerViewModel);
            beer.Brewery = brewery;
            result.SuccessResult = _mapper.Map<BeerDto>(beer); 
            _beerRepository.Insert(beer);

            return result;
        }

        public ResultDto<BeerDto> Edit(int id, BeerViewModel beerViewModel)
        {
            var result = new ResultDto<BeerDto>();

            var beer = _beerRepository.GetBy(x => x.Id == id);
            if(beer == null)
            {
                result.Errors.Add("Nie znaleziono takiego piwa");
                return result;
            }
            _mapper.Map(beerViewModel, beer);
            var brewery = _breweryRepository.GetBy(x => x.Id == beerViewModel.BreweryId);
            beer.Brewery = brewery;
            if (brewery == null)
            {
                result.Errors.Add("Nie istnieje taki browar");
                return result;
            }
            if (_beerRepository.Exist(x => x.Name == beerViewModel.Name && x.Brewery.Id == beerViewModel.BreweryId))
            {
                result.Errors.Add("Piwo o podanej nazwie jest już dodane do browaru");
                return result;
            }
            _beerRepository.Update(beer);
            result.SuccessResult = _mapper.Map<BeerDto>(beer);       
            return result;

        }

        public ResultDto<BeerDto> Delete(int id)
        {
            var result = new ResultDto<BeerDto>();

            var beer = _beerRepository.GetBy(x => x.Id == id);
            if (beer == null)
            {
                result.Errors.Add("Nie znaleziono takiego piwa");
                return result;
            }
            _beerRepository.Delete(x => x.Id == id);

            result.SuccessResult = _mapper.Map<BeerDto>(beer);

            return result;


        }




    }
}

