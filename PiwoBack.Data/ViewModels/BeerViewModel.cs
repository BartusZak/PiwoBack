using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiwoBack.Data.ViewModels
{
    public class BeerViewModel
    {
        [Required]
        [StringLength(14, ErrorMessage = "Nazwa piwa powinna mieć od 8 do 14 znaków", MinimumLength = 8)]
        public string Name { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "Opis powinien mieć od 10 do 80 znaków", MinimumLength = 8)]
        public string Description { get; set; }
        [Required]
        public double Alcohol { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public double Ibu { get; set; }
        [Required]
        public double Blg { get; set; }
        [Required]
        public int BreweryId { get; set; }

        public IEnumerable<int> CommentsIds { get; set; }
    }
}
