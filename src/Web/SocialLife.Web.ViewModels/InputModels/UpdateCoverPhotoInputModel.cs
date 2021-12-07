namespace SocialLife.Web.ViewModels.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using SocialLife.Web.Infrastructure.Attributes;

    public class UpdateCoverPhotoInputModel
    {
        [Picture(ErrorMessage = "You are trying to upload a file that is not an image.")]
        [Required(ErrorMessage = "Please upload your desired picture.")]
        public IFormFile CoverPhoto { get; set; }
    }
}
