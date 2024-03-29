﻿using EndlessBoard_backend.classes;
using Microsoft.EntityFrameworkCore;
namespace EndlessBoard_backend.models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entuty =>
            {
                entuty.HasIndex(e => e.Username).IsUnique();
            });
        }
        public DbSet<ReactionList> ReactionList { get; set; }

        public DbSet<Reaction> Reactions { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
