namespace SocialLife.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using SocialLife.Data.Common.Models;

    public class Attachment : BaseModel<int>
    {
        [Required]
        public string Url { get; set; }

        [Required]
        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string AttachedById { get; set; }

        public virtual ApplicationUser AttachedBy { get; set; }
    }
}
