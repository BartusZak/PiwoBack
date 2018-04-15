using System;
using System.Collections.Generic;
using System.Text;

namespace PiwoBack.Data.DTOs
{
    public class BreweryDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BrewingGroupChildDto BrewingGroup { get; set; }
        public virtual IEnumerable<BeerChildDto> Beers { get; set; }
    }
}
