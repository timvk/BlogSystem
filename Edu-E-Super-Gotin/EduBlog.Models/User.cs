using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EduBlog.Models
{
    public class User : IdentityUser
    {
        private ICollection<Article> articles;
        private ICollection<Comment> comments;
        private ICollection<Message> sentMessages;
        private ICollection<Message> receivedMessages;
        private ICollection<User> friends; 

        public User()
        {
            this.comments = new HashSet<Comment>();
            this.articles = new HashSet<Article>();
            this.sentMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
            this.friends = new HashSet<User>();
        }

        public DateTime? BirthDate { get; set; }

        public Gender Gender { get; set; }

        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
            
        }

        public virtual ICollection<Message> SentMessages
        {
            get { return this.sentMessages; }
            set { this.sentMessages = value; }
            
        }

        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }

        public virtual ICollection<User> Friends
        {
            get { return this.friends; }
            set { this.friends = value; }
            
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
