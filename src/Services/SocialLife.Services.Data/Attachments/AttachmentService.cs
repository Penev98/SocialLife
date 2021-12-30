namespace SocialLife.Services.Data.Attachments
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using SocialLife.Data.Common.Repositories;
    using SocialLife.Data.Models;

    public class AttachmentService : IAttachmentService
    {
        private readonly IRepository<Attachment> attachmentsRepo;

        public AttachmentService(IRepository<Attachment> attachmentsRepo)
        {
            this.attachmentsRepo = attachmentsRepo;
        }

        public async Task CreateAttachmentAsync(IFormFile attachment, string postId, string userId)
        {
            Attachment att = new Attachment()
            {
                AttachedById = userId,
                PostId = postId,
                Url = attachment.FileName,
                FileExtension = Path.GetExtension(attachment.FileName),
            };

            await this.attachmentsRepo.AddAsync(att);
            await this.attachmentsRepo.SaveChangesAsync();
        }

        public async Task CreateAttachmentAsync(ICollection<IFormFile> attachments, string postId, string userId)
        {
            foreach (var item in attachments)
            {
                Attachment att = new Attachment()
                {
                    AttachedById = userId,
                    PostId = postId,
                    Url = item.FileName,
                    FileExtension = Path.GetExtension(item.FileName),
                };

                await this.attachmentsRepo.AddAsync(att);
            }

            await this.attachmentsRepo.SaveChangesAsync();
        }
    }
}
