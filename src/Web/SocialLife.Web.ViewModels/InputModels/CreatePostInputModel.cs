namespace SocialLife.Web.ViewModels.InputModels
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreatePostInputModel : IValidatableObject
    {
        public CreatePostInputModel()
        {
            this.Attachments = new List<IFormFile>();
        }

        [Required(ErrorMessage = "You cannot create an empty post.")]
        public string Content { get; set; }

        public ICollection<IFormFile> Attachments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
                foreach (var item in this.Attachments)
                {
                    if (!(item.FileName.EndsWith(".png")
                        || item.FileName.EndsWith(".jpeg")
                        || item.FileName.EndsWith(".jpg")
                        || item.FileName.EndsWith(".gif")
                        || item.FileName.EndsWith(".mp4")
                        || item.FileName.EndsWith(".avi")
                        || item.FileName.EndsWith(".wmv")))
                    {
                        yield return new ValidationResult(
                            errorMessage: "You are trying to upload an invalid type of file.",
                            memberNames: new[] { "Attachments" });
                    }
                }
        }
    }
}
