namespace SocialLife.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SocialLife.Data.Models;
    using SocialLife.Services.Data;
    using SocialLife.Services.Data.Attachments;
    using SocialLife.Services.Data.Pictures;
    using SocialLife.Services.Data.Profile;
    using SocialLife.Web.ViewModels;
    using SocialLife.Web.ViewModels.InputModels;
    using SocialLife.Web.ViewModels.Posts;

    public class UserTimelineController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostService postService;
        private readonly IProfileService profileService;
        private readonly IPictureService pictureService;
        private readonly IWebHostEnvironment webHost;
        private readonly IAttachmentService attachmentService;

        public UserTimelineController(
            UserManager<ApplicationUser> userManager,
            IPostService postService,
            IProfileService profileService,
            IPictureService pictureService,
            IWebHostEnvironment webHost,
            IAttachmentService attachmentService)
        {
            this.userManager = userManager;
            this.postService = postService;
            this.profileService = profileService;
            this.pictureService = pictureService;
            this.webHost = webHost;
            this.attachmentService = attachmentService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userPosts = this.postService.GetAllUserPosts<UserPostViewModel>(await this.GetUserId());
            this.ViewBag.Models = userPosts;

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(CreatePostInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Index", model);
            }

            string userId = await this.GetUserId();

            // create the post and add it to the db => get it's id
            string createdPostId = await this.postService.CreatePostAsync(model, userId);

            // check if the model has attachments
            if (model.Attachments.Count > 0)
            {
                string webRootPath = this.webHost.WebRootPath;
                string folderName = "\\PostAttachments\\";

                // save the attachments in the file system
                await this.pictureService.SavePictureAsync(model.Attachments, webRootPath, folderName);

                // add ref for each attachment in the db
                await this.attachmentService.CreateAttachmentAsync(model.Attachments, createdPostId, userId);
            }

            return this.RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> DeletePost(string id)
        {
            string userId = await this.GetUserId();

            var result = await this.postService.DeleteUserPostAsyns(id, userId);

            if (result)
            {
                return this.RedirectToAction("Index");
            }

            return this.Json("Invalid operation attempt");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditPost(UserPostViewModel updatedPost)
        {
            string userId = await this.GetUserId();

            var result = await this.postService.EditUserPostAsync(updatedPost, userId);

            if (result)
            {
                return this.RedirectToAction("Index");
            }

            return this.Json("Invalid operation attempt");
        }

        public async Task<IActionResult> RemoveProfilePicture()
        {
            await this.profileService.RemoveUserProfilePictureAsync(await this.GetUserId());
            return this.Redirect("/");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateUserCoverPhoto(UpdateCoverPhotoInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView("_UploadCoverPhotoModalPartial", model);
            }

            string webRootPath = this.webHost.WebRootPath;
            string folderName = "\\CoverPhotos\\";

            await this.pictureService.SavePictureAsync(model.CoverPhoto, webRootPath, folderName);

            await this.profileService.UpdateUserCoverPhotoAsync(await this.GetUserId(), model);

            return this.Redirect("/");
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        private async Task<string> GetUserId()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            return user.Id;
        }
    }
}
