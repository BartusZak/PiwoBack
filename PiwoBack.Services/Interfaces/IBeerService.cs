using System;
using System.Collections.Generic;
using System.Text;
using PiwoBack.Data.DTOs;
using PiwoBack.Data.Models;
using PiwoBack.Data.ViewModels;

namespace PiwoBack.Services.Interfaces
{
    public interface IBeerService
    {
        IEnumerable<BeerDto> GetAll();
        BeerDto GetBeer(int id);
        ResultDto<BeerDto> Insert(BeerViewModel beerViewModel);
        ResultDto<BeerDto> Edit(int id, BeerViewModel beerViewModel);
        ResultDto<BeerDto> Delete(int id);
    }
}
 