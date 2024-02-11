using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace EndlessBoard_backend.classes
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username îáÿçàòåëüíî äëÿ çàïîëíåíèÿ")]
        public string Username { get; set; }
        [Required(ErrorMessage = "PasswordHash îáÿçàòåëüíî äëÿ çàïîëíåíèÿ")]
        public string PasswordHash { get; set; }
        public int? AvatarId { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>(); // äîáàâëÿåì ê ïîëüçîâàòåëþ êîëëåêöèþ åãî êîììåíòàðèåâ, ÷òîáû áûëî êàê íà Reddit
        public List <Post> Posts { get; set; } = new List<Post>();

    }
}




