using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EndlessBoard_backend.classes
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string? Text { get; set; }

        [Required(ErrorMessage = "UserId ����������� ��� ����������")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "Date ����������� ��� ����������")]
        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        //������ Post_class �������� ������ ����������, ����� ��� ����������� ����� � ������ �� ������

        public int? ImageId { get; set; }
        public bool IsEdit { get; set; } = false;
    }
}
