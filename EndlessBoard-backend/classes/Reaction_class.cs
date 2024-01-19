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

        [Required(ErrorMessage = "Text обязательно для заполнения")]
        public string Text { get; set; }

        public int UserId { get; set; } // Внешний ключ для пользователя

        [ForeignKey("UserId")]
        public User User { get; set; } // Навигационное свойство для пользователя
        //теперь мы будем хранить инфо о юзере в реакции чтобы реализовать Reaction_list и показывать статистику и информацию
    }
}