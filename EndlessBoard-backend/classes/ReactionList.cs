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


        // Добавляем внешний ключ для пользователя
        public int UserId { get; set; }
        public User User { get; set; } // Навигационное свойство для пользователя

        public int PostId { get; set; }
        public Post Post { get; set; } // Навигационное свойство для поста

        public int ReactionId { get; set; }
        public Reaction Reaction { get; set; }
    }
}
