namespace SocialLife.Services.Data.Post
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPostLikesService
    {
        public Task<bool> CheckUserPostLike(string postId, string userId);

        public Task<bool> AddUserToPostLikes(string postId, string userId);

        public Task<bool> RemoveUserFromPostLikes(string postId, string userId);

        public Task IncrementPostLikesCount(string postId);

        public Task DecrementPostLikesCount(string postId);
    }
}
