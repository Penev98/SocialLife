using SocialLife.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialLife.Data.Models
{
    public class Post : BaseDeletableModel<string>
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Attachments = new HashSet<Attachment>();
            this.LikedByUsers = new HashSet<UserLikedPost>();
        }

        public int LikesCount { get; set; }

        public string TextContent { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<UserLikedPost> LikedByUsers { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
