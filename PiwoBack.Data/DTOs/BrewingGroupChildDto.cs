using System;
using System.Collections.Generic;
using System.Text;

namespace PiwoBack.Data.DTOs
{
    public class BrewingGroupChildDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
