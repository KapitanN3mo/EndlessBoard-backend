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

        [Required(ErrorMessage = "Username ����������� ��� ����������")]
        public string Username { get; set; }
        [Required(ErrorMessage = "PasswordHash ����������� ��� ����������")]
        public string PasswordHash { get; set; }
        public int? AvatarId { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>(); // ��������� � ������������ ��������� ��� ������������, ����� ���� ��� �� Reddit

        public List <Post> Posts { get; set; } = new List<Post>();



    }
}




