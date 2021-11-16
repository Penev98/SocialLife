using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialLife.Web.ViewModels.Posts
{
    public class CreatePostInputModel
    {
        [Required(ErrorMessage = "You cannot create an empty post.")]
        public string Content { get; set; }
    }
}
