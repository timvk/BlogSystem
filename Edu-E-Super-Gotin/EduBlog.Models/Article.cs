using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBlog.Models
{
    public class Article
    {
        private ICollection<Comment> comments;

        public Article()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }

        public DateTime? PostedOn { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }

        }
    }
}
