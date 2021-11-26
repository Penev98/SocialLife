namespace SocialLife.Services.Data.Pictures
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public class PictureService : IPictureService
    {
        public async Task SaveProfilePictureAsync(IFormFile profilePicture, string webRoot)
        {
            string picPath = webRoot + "\\ProfilePictures\\" + profilePicture.FileName;

            using (FileStream fs = new FileStream(picPath, FileMode.Create))
            {
                profilePicture.OpenReadStream();
                await profilePicture.CopyToAsync(fs);
            }

        }
    }
}
