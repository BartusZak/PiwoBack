using PiwoBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwoBack.Data.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }
    }
}
