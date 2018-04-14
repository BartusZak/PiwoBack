using System;
using System.Collections.Generic;
using System.Text;
using PiwoBack.Data.DTOs;


namespace PiwoBack.Services.Interfaces
{
    public interface IBeerService
    {
        IEnumerable<BeerDto> GetAll();
        BeerDto GetBeer(int id);
    }
}
