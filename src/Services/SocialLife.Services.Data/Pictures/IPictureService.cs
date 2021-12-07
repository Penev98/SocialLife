namespace SocialLife.Services.Data.Pictures
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IPictureService
    {
        public Task SavePictureAsync(IFormFile profilePicture, string webRoot, string folderName);

    }
}
