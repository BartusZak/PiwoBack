using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiwoBack.Data.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "Nazwa użytkownika powinna mieć od 5 do 30 znaków", MinimumLength = 2)]
        [RegularExpression("^[a-zA-Z0-9_-]*$", ErrorMessage = "Nazwa użytkownia może składać się z liter, cyfr, '_', '_'")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "Hasło powinno mieć od 5 do 30 znaków", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Hasło powinno mieć od 5 do 30 znaków", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmedPassword { get; set; }
    }
}
