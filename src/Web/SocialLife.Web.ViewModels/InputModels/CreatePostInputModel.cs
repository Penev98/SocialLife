namespace SocialLife.Web.ViewModels.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreatePostInputModel
    {
        [Required(ErrorMessage = "You cannot create an empty post.")]
        public string Content { get; set; }
    }
}
