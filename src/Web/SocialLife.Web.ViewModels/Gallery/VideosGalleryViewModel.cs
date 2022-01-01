using SocialLife.Data.Models;
using SocialLife.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLife.Web.ViewModels.Gallery
{
   public class VideosGalleryViewModel : IMapFrom<Attachment>
    {
        public string Url { get; set; }
    }
}
