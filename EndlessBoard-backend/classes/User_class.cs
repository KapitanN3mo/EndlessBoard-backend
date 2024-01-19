using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        public int AvatarId { get; set; }

        public virtual ICollection<Comment_class> Comments { get; set; } // ��������� � ������������ ��������� ��� ������������, ����� ���� ��� �� Reddit


    }



  









}