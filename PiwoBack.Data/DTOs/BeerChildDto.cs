using System;
using System.Collections.Generic;
using System.Text;

namespace PiwoBack.Data.DTOs
{
    public class BeerChildDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Alcohol { get; set; }
        public double Price { get; set; }
    }
}
