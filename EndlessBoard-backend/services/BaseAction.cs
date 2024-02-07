using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using EndlessBoard_backend.models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Hosting;
using BCrypt.Net;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EndlessBoard_backend.classes
{
    public class BaseAction
    {
        private readonly ApplicationContext _context;

        public BaseAction(ApplicationContext context)
        {
            _context = context;
        }

        public bool AddComment(Post post, int userId, string UserComm)
        {

            User user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
            
                Comment newComment = new Comment()
                {
                    Text = UserComm,
                    UserId = user.Id,
                    PostId = post.Id,
                    Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
                };


                _context.Comments.Add(newComment);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }


        public Post? AddPost(int userId, string Text, int? ImageId)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {

                Post newPost = new Post()
                {
                    Text = Text,
                    ImageId = ImageId,
                    UserId = userId,
                    Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)

            };
                _context.Posts.Add(newPost);
                _context.SaveChanges();
                return newPost;

            }
            else { return null; }
        }

        public bool DeletePost(int postId)
        {
            Post post = _context.Posts.FirstOrDefault(u => u.Id == postId);

            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteComment(int commentId)
        {

            Comment comment = _context.Comments.FirstOrDefault(u => u.Id == commentId);

            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public User AddUser(string username, bool gender, int? avatarId, string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

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
            return newUser;

        }




            public bool AddReactionList(int userId, int postId, int reactionId)
            {
            try
            {
                ReactionList newReactionList = new ReactionList
                {
                    UserId = userId,
                    PostId = postId,
                    ReactionId = reactionId
                };

                _context.ReactionList.Add(newReactionList);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
            }


        public bool RemoveReactionList(int listId)
        {
            ReactionList removeInfo = _context.ReactionList.FirstOrDefault(x => x.Id == listId);

            if (removeInfo != null)
            {
                _context.ReactionList.Remove(removeInfo);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public bool AddReaction (string reaction)
        {
            try
            {
                var Newreaction = new Reaction { Text = reaction };
                _context.Reactions.Add(Newreaction);
                _context.SaveChanges();
                return true;
            } catch (Exception ex) { Console.WriteLine($"{ex} - can not to create Reaction, try to fix it"); return false; }

        }

        public bool DeleteReaction (int reactID)
        {
            Reaction thisReact = _context.Reactions.FirstOrDefault(e => e.Id == reactID);
            if (thisReact != null)
            {
                _context.Reactions.Remove(thisReact);
                _context.SaveChanges();
                return true;
            }
            else { return false; };
        }

        public bool RemoveUser(int userId)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                Console.WriteLine($"Remove User: {userId} by named: {user.Username}");
                return true;
            }
            else { return false; }
        }



    } 

    

}