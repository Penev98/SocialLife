namespace SocialLife.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : BaseController
    {
        [Authorize]
        public IActionResult LikePost(string postId)
        {
            // Check if the user attempting to like a post is in the post likes
                // use a service to add the user to post likes
                // use a service to increment the post likes count
            if (postId == "hello")
            {
                return this.Json(true);
            }

            return this.Json(false);
        }

        [Authorize]
        public IActionResult DislikePost(string postId)
        {
            // Check if the user attempting to dislike a post is in the post likes
                // use a service to remove the user from the post likes
                // use a service to decrement the post likes count
            if (postId == "hello")
            {
                return this.Json(true);
            }

            return this.Json(false);
        }
    }
}
