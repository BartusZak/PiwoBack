using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PiwoBack.Data.ViewModels
{
    public class CommentViewModel { 
        [Required]
        public int Rate { get; set; }
        public string Content { get; set; }
        [Required]
        public int BeerId { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}
