using PiwoBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwoBack.Data.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
