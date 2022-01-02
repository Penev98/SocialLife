﻿using Microsoft.AspNetCore.Mvc;
using SocialLife.Services.Data.Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialLife.Web.Controllers
{
    public class PhotoGalleryController : BaseController
    {
        private readonly IGalleryService galleryService;

        public PhotoGalleryController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }

        public IActionResult Index()
        {
            var models = this.galleryService.GetUserPhotoModels(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return this.View(models);
        }
    }
}
