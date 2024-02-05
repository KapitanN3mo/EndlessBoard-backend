using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace EndlessBoard_backend.classes
{

    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username ����������� ��� ����������")]

       
        public string Username { get; set; }
        [Required(ErrorMessage = "PasswordHash ����������� ��� ����������")]
        public string PasswordHash { get; set; }
        public int? AvatarId { get; set; }

        public bool gender { get; set; } // male is "true"

        public List<Comment> Comments { get; set; } = new List<Comment>(); // ��������� � ������������ ��������� ��� ������������, ����� ���� ��� �� Reddit

        public List <Post> Posts { get; set; } = new List<Post>();



    }
}




