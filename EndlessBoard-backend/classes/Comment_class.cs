using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndlessBoard_backend.classes
{
    public class Comment_class
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Текст обязательно для заполнения")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Autor_id обязательно для заполнения")]

        [ForeignKey("AutorId")]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "Date обязательно для заполнения")]
         public DateTime Date { get; set; }

        [Required(ErrorMessage = "Post_id обязательно для заполнения")]

        [ForeignKey("PostId")]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual User Autor { get; set; }


    }
}
