using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
System.Collections.Generic


namespace EndlessBoard_backend.classes
{

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username обязательно для заполнения")]
        public string Username { get; set; }
        [Required(ErrorMessage = "PasswordHash обязательно для заполнения")]
        public string PasswordHash { get; set; }
        public int? AvatarId { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>(); // добавляем к пользователю коллекцию его комментариев, чтобы было как на Reddit

        public List <Post> Posts { get; set; } = new List<Post>();



    }
}




