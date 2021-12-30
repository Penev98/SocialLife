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
        public async Task SavePictureAsync(IFormFile picture, string webRoot, string folderName)
        {
            string picPath = webRoot + folderName + picture.FileName;

            using (FileStream fs = new FileStream(picPath, FileMode.Create))
            {
                picture.OpenReadStream();
                await picture.CopyToAsync(fs);
            }

        }

        public async Task SavePictureAsync(ICollection<IFormFile> pictures, string webRoot, string folderName)
        {
            foreach (var picture in pictures)
            {
                string picPath = webRoot + folderName + picture.FileName;

                using (FileStream fs = new FileStream(picPath, FileMode.Create))
                {
                    picture.OpenReadStream();
                    await picture.CopyToAsync(fs);
                }
            }
        }
    }
}
