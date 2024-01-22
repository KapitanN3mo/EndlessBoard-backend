using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic; // Добавляем using для List
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

        // Изменяем навигационное свойство на список реакций
        public List<Reaction> Reactions { get; set; } = new List<Reaction>();
    }
}
