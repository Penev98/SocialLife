using SocialLife.Data.Models;
using SocialLife.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLife.Web.ViewModels.Gallery
{
   public class PhotosGalleryViewModel : IMapFrom<Attachment>
    {
        public string Url { get; set; }

        public string PostTextContent { get; set; }

        public int PostLikesCount { get; set; }
    }
}
