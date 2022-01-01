using SocialLife.Web.ViewModels.Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLife.Services.Data.Gallery
{
  public interface IGalleryService
    {
        public ICollection<PhotosGalleryViewModel> GetUserPhotoModels(string userId);

        public ICollection<VideosGalleryViewModel> GetUserVideoModels(string userId);
    }
}
