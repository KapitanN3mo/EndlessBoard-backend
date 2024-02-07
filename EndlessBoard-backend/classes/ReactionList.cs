using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndlessBoard_backend.classes
{
    public class ReactionList
    {
        [Key]
        public int Id { get; set; }

        // добавляем внешний ключ пользователя
        public int UserId { get; set; }
        public User User { get; set; } // навигационное свойство пользователя

        public int PostId { get; set; }
        public Post Post { get; set; } // навигационное свойство поста

        public int ReactionId { get; set; }
        public Reaction Reaction { get; set; }
    }
}
