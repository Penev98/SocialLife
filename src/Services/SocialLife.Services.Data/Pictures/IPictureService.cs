namespace SocialLife.Services.Data.Pictures
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IPictureService
    {
        public Task SavePictureAsync(IFormFile picture, string webRoot, string folderName);

        public Task SavePictureAsync(ICollection<IFormFile> pictures, string webRoot, string folderName);

    }
}
