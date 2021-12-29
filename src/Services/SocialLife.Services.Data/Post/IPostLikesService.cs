namespace SocialLife.Services.Data.Post
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPostLikesService
    {
        public bool CheckUserPostLike(string postId, string userId);

        public Task AddUserToPostLikesAsync(string postId, string userId);

        public Task RemoveUserFromPostLikesAsync(string postId, string userId);

        public Task IncrementPostLikesCountAsync(string postId);

        public Task DecrementPostLikesCountAsync(string postId);

        public Task<int> PostLikesCount(string postId);
    }
}
