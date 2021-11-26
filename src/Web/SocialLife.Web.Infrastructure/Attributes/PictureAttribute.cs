namespace SocialLife.Web.Infrastructure.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class PictureAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            IFormFile file = value as IFormFile;

            if (!file.FileName.EndsWith(".png") && !file.FileName.EndsWith(".jpg"))
            {
                return false;
            }

            return true;
        }
    }
}
