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

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }

       //public int ReactionId { get; set; }
        public ICollection<Reaction> Reactions { get; set; } // Навигационное свойство для коллекции реакций

        public ICollection<User> Users { get; set; } // Навигационное свойство для коллекции пользователей

        //теперь Reaction_list полностью оправдывает своё название и хранит коллекцию реакций и пользователей которые взаимодействовали или просматривали
    }
}
