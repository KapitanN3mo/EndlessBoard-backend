using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndlessBoard_backend.classes
{
    public class Reaction
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Text не может быть пустым")]
        public string Text { get; set; }

       
    }
}
