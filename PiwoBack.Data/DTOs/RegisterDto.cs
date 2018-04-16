using System;
using System.Collections.Generic;
using System.Text;

namespace PiwoBack.Data.DTOs
{
    public class RegisterDto: BaseIdDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
