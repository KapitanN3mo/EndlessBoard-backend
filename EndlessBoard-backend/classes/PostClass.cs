using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EndlessBoard_backend.classes
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string? Text { get; set; }


        [Required()]
        public int UserId { get; set; }
      
        public User User { get; set; }
      
        [Required()]
        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public int? ImageId { get; set; }
        public bool IsEdit { get; set; } = false;
    }
}
