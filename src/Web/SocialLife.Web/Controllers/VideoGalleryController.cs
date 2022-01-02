using Microsoft.AspNetCore.Mvc;
using SocialLife.Services.Data.Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialLife.Web.Controllers
{
    public class VideoGalleryController : BaseController
    {
        private readonly IGalleryService galleryService;

        public VideoGalleryController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }

        public IActionResult Index()
        {
            var models = this.galleryService.GetUserVideoModels(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return this.View(models);
        }
    }
}
