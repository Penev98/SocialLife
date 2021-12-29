namespace SocialLife.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SocialLife.Services.Data.Post;

    public class PostsController : BaseController
    {
        private readonly IPostLikesService postLikesService;

        public PostsController(IPostLikesService postLikesService)
        {
            this.postLikesService = postLikesService;
        }

        [Authorize]
        public async Task<IActionResult> LikePost(string postId)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Check if the user attempting to like a post is in the post likes
            if (this.postLikesService.CheckUserPostLike(postId, userId))
            {
                return this.Json(false);
            }

            // use a service to add the user to post likes
            await this.postLikesService.AddUserToPostLikesAsync(postId, userId);

            // use a service to increment the post likes count
            await this.postLikesService.IncrementPostLikesCountAsync(postId);

            return this.Json(true);
        }

        [Authorize]
        public async Task<IActionResult> DislikePost(string postId)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Check if the user attempting to dislike a post is in the post likes
            if (!this.postLikesService.CheckUserPostLike(postId, userId))
            {
                return this.Json(false);
            }

            // use a service to remove the user from the post likes
            await this.postLikesService.RemoveUserFromPostLikesAsync(postId, userId);

            // use a service to decrement the post likes count
            await this.postLikesService.DecrementPostLikesCountAsync(postId);

            return this.Json(true);
        }

        public async Task<IActionResult> GetPostLikesCount(string postId)
        {
             var res = await this.postLikesService.PostLikesCount(postId);

             return this.Json(res);
        }
    }
}
