

using EduBlog.Data.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EduBlog.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using EduBlog.Models;

    public class BlogContext : IdentityDbContext<User>
    {
        public BlogContext()
            : base("BlogContext")
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>()); 
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedMessages)
                .WithRequired(m => m.Receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SentMessages)
                .WithRequired(m => m.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("UsersFriends");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                });

            base.OnModelCreating(modelBuilder);
        }

        public static BlogContext Create()
        {
            return new BlogContext();
        }


    }
}