using PiwoBack.Data.DTOs;
using PiwoBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwoBack.Services.Interfaces
{
    public interface IBreweryService
    {
        IEnumerable<BreweryDto> GetAll();
        BreweryDto GetBrewery(int id);
    }
}
