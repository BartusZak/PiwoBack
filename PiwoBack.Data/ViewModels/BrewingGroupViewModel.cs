using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiwoBack.Data.ViewModels
{
    public class BrewingGroupViewModel
    {
        [Required]
        [StringLength(14, ErrorMessage = "Nazwa powinna mieć od 8 do 14 znaków", MinimumLength = 8)]
        public string Name { get; set; }
        [StringLength(8, ErrorMessage = "Adres powinien mieć od 8 do 20 znaków", MinimumLength = 20)]
        public string Address { get; set; }
        [StringLength(80, ErrorMessage = "Opis powinien mieć od 8 do 80 znaków", MinimumLength = 8)]
        public string Description { get; set; }
        [Required]
        [StringLength(14, ErrorMessage = "Nazwa prezesa powinna mieć od 8 do 14 znaków", MinimumLength = 8)]
        public string Director { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DateValidator(ErrorMessage = "Niepoprawna data")]
        public DateTime CreateDate { get; set; }
        [Required]
        public IEnumerable<int> BreweriesIds { get; set; }
    }
}
