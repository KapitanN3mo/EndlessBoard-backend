using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using EndlessBoard_backend.models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Hosting;
using BCrypt.Net;
using System.Reflection.Metadata.Ecma335;

namespace EndlessBoard_backend.classes
{
    public class UserAction
    {
        private readonly ApplicationContext _context;

        public UserAction(ApplicationContext context)
        {
            _context = context;
        }

        public void AddComment(Comment comment, string IsUsername, string UserComm)
        {
            // Получаем пользователя по его имени
            User user = _context.Users.FirstOrDefault(u => u.Username == IsUsername);

            if (user != null)
            {
                // Создаем новый комментарий
                Comment newComment = new Comment()
                {
                    Text = UserComm,
                    UserId = user.Id
                };

                // Добавляем комментарий в базу данных
                _context.Comments.Add(newComment);
                _context.SaveChanges();
            }
        }

        // ... (other methods)

        public void AddPost(Post post, int userId, string Text, int? ImageId)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == userId);

            Post newPost = new Post()
            {
                Text = Text,
                ImageId = ImageId,
                UserId = userId,
                Date = DateTime.Now

            };
            _context.Posts.Add(newPost);
            _context.SaveChanges();

        }

        public void DeletePost(int postId)
        {
            Post post = _context.Posts.FirstOrDefault(u => u.Id == postId);

            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
                Console.WriteLine("db changes saved successfully");
            }
            else
            {
                Console.WriteLine("comment not found");
            }

        }

        public void DeleteComment(int commentId)
        {

            Comment comment = _context.Comments.FirstOrDefault(u => u.Id == commentId);

            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
                Console.WriteLine("db changes saved successfully");
            }
            else
            {
                Console.WriteLine("comment not found");
            }
        }

        public string AddUser(User user, string username, bool gender, int? avatarId, string password)
        {
            // Генерация соли
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Хеширование пароля с использованием соли
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);
            User newUser = new User()
            {
                Username = username,
                gender = gender,
                AvatarId = avatarId,
                PasswordHash = passwordHash,
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return salt;
        }


         public void AddReactionList(int userId, int postId, int reactionId)
            {
                // Логика добавления новой записи в таблицу ReactionList
                ReactionList newReactionList = new ReactionList
                {
                    UserId = userId,
                    PostId = postId,
                    ReactionId = reactionId
                };

                _context.ReactionList.Add(newReactionList);
                _context.SaveChanges();
            }


        public void RemoveReactionList(int listId)
        {
            ReactionList removeInfo = _context.ReactionList.FirstOrDefault(x => x.Id == listId);

            if (removeInfo != null)
            {
                _context.ReactionList.Remove(removeInfo);
                _context.SaveChanges();
            }





        }

        public void removeUser(int userId)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }



    } 

    

}