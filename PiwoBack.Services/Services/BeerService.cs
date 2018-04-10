﻿using System;
using System.Collections.Generic;
using System.Text;
using PiwoBack.Data.Models;
using PiwoBack.Repository.Interfaces;
using PiwoBack.Services.Interfaces;

namespace PiwoBack.Services.Services
{
    public class BeerService : IBeerService
    {
        private readonly IRepository<Beer> _beerRepository;

        public BeerService(IRepository<Beer> beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public IEnumerable<Beer> GetAll()
        {
            var beers = _beerRepository.GetAll();
            return beers;
        }

        public Beer GetBeer(int id)
        {
            var beer = _beerRepository.GetBy(x => x.Id == id);

            if (beer == null)
            {
                return null;
            }

            return beer;
        }
    }
}
