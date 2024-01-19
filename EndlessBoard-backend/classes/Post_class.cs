using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndlessBoard_backend.classes
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        [Required(ErrorMessage = "Autor_id обязательно для заполнения")]

        [ForeignKey("AutorId")]
        public int AutorId { get; set; }

        public virtual User Autor { get; set; }

        [Required(ErrorMessage = "Date обязательно для заполнения")]
        public DateTime Date { get; set; }

        public virtual ICollection<Comment_class> Comments { get; set; }

        //теперь Post_class содержит больше информации, такую как комментарии поста и ссылка на автора

        public int ImageId { get; set; }
        public bool IsEdit { get; set; } = false;
    }
}
