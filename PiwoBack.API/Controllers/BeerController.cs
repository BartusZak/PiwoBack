using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiwoBack.Data.Models;
using PiwoBack.Data.ViewModels;
using PiwoBack.Services.Interfaces;

namespace PiwoBack.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BeerController : Controller
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet]
        public IActionResult GetBeers()
        {
            var beers = _beerService.GetAll();
            return Ok(beers);
        }

        [HttpGet("{id}")]
        public IActionResult GetBeer(int id)
        {
            var beer = _beerService.GetBeer(id);

            if (beer == null)
            {
                return NotFound();
            }
            return Ok(beer);
        }

        [HttpPost("insert")]
        public IActionResult Add([FromBody]BeerViewModel beerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _beerService.Insert(beerViewModel);
            if(result.IsError)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);

        }


        [HttpPost("edit/{id}")]
        public IActionResult Edit(int id,[FromBody] BeerViewModel beerViewModel)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _beerService.Edit(id, beerViewModel);
            return Ok(result);

        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var result = _beerService.Delete(id);
            return Ok(result);

        }
    }
}