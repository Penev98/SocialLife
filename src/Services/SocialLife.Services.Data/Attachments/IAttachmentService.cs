namespace SocialLife.Services.Data.Attachments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IAttachmentService
    {
        public Task CreateAttachmentAsync(IFormFile attachment, string postId, string userId);

        public Task CreateAttachmentAsync(ICollection<IFormFile> attachments, string postId, string userId);
    }
}
