namespace SocialLife.Services.Data.Gallery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SocialLife.Data.Common.Repositories;
    using SocialLife.Data.Models;
    using SocialLife.Services.Mapping;
    using SocialLife.Web.ViewModels.Gallery;

    public class GalleryService : IGalleryService
    {
        private readonly string[] photoExtensions;
        private readonly string[] videoExtension;
        private readonly IRepository<Attachment> attachmentRepo;

        public GalleryService(IRepository<Attachment> attachmentRepo)
        {
            this.attachmentRepo = attachmentRepo;
            this.photoExtensions = new string[] { ".png", ".jpeg", ".jpg" };
            this.videoExtension = new string[] { ".gif", ".mp4", ".wmv", ".avi" };
        }

        public ICollection<PhotosGalleryViewModel> GetUserPhotoModels(string userId)
        {
            return this.attachmentRepo.AllAsNoTracking()
                .Where(x => x.AttachedById == userId && this.photoExtensions.Contains(x.FileExtension))
                .To<PhotosGalleryViewModel>()
                .ToList();
        }

        public ICollection<VideosGalleryViewModel> GetUserVideoModels(string userId)
        {
            return this.attachmentRepo.AllAsNoTracking()
                .Where(x => x.AttachedById == userId && this.videoExtension.Contains(x.FileExtension))
                .To<VideosGalleryViewModel>()
                .ToList();
        }
    }
}
