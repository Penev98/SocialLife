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
        public async Task SavePictureAsync(IFormFile profilePicture, string webRoot, string folderName)
        {
            string picPath = webRoot + folderName + profilePicture.FileName;

            using (FileStream fs = new FileStream(picPath, FileMode.Create))
            {
                profilePicture.OpenReadStream();
                await profilePicture.CopyToAsync(fs);
            }

        }
    }
}
