﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndlessBoard_backend.classes
{
    public class Comment
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Текст обязательно для заполнения")]
        public string Text { get; set; }



        [Required(ErrorMessage = "Date не может быть пустым")]
         public DateTime Date { get; set; }

        [Required(ErrorMessage = "Post_id не может быть пустым")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


    }
}
