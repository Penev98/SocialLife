namespace SocialLife.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SocialLife.Services.Data.Pictures;
    using SocialLife.Services.Data.Profile;
    using SocialLife.Web.ViewModels.InputModels;

    public class ProfileController : BaseController
    {
        private readonly IProfileService profileService;
        private readonly IPictureService pictureService;
        private readonly IWebHostEnvironment webHost;

        public ProfileController(IProfileService profileService, IPictureService pictureService, IWebHostEnvironment webHost)
        {
            this.profileService = profileService;
            this.pictureService = pictureService;
            this.webHost = webHost;
        }

        public IActionResult EditPersonalInfo()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditPersonalInfo(UpdateProfileInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            string webRoot = this.webHost.WebRootPath;
            string profilePicturesFolder = "\\ProfilePictures\\";

            if (model.ProfilePicture != null)
            {
                await this.pictureService.SavePictureAsync(model.ProfilePicture, webRoot, profilePicturesFolder);
            }

            await this.profileService.UpdateUserInfoAsync(model, userId, model.ProfilePicture == null ? string.Empty : model.ProfilePicture.FileName);

            return this.Redirect("/");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(string aboutDescription)
        {
           await this.profileService.UpdateUserAboutAsync(this.User.FindFirstValue(ClaimTypes.NameIdentifier), aboutDescription);

           return this.Redirect("/");
        }
    }
}
