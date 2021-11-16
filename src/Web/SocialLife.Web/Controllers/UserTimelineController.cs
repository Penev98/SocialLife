namespace SocialLife.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SocialLife.Data.Models;
    using SocialLife.Services.Data;
    using SocialLife.Web.ViewModels;
    using SocialLife.Web.ViewModels.Posts;

    public class UserTimelineController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostService postService;

        public UserTimelineController(UserManager<ApplicationUser> userManager, IPostService postService)
        {
            this.userManager = userManager;
            this.postService = postService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            this.ViewBag.Models = this.postService.GetAllUserPosts<UserPostViewModel>(await this.GetUserId());

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(CreatePostInputModel model)
        {
            string userId = await this.GetUserId();

            await this.postService.CreatePostAsync(model, userId);

            return this.RedirectToAction("Index");
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
