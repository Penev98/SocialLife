namespace SocialLife.Services.Data.Post
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SocialLife.Data.Common.Repositories;
    using SocialLife.Data.Models;

    public class PostLikesService : IPostLikesService
    {
        private readonly IDeletableEntityRepository<Post> postsRepo;

        public PostLikesService(IDeletableEntityRepository<Post> postsRepo /*ApplicationDbContext dbContext*/)
        {
            this.postsRepo = postsRepo;
        }

        public async Task<bool> AddUserToPostLikes(string postId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckUserPostLike(string postId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task DecrementPostLikesCount(string postId)
        {
            var postToModify = this.postsRepo.All().FirstOrDefault(x => x.Id == postId);

            if (postToModify != null)
            {
                postToModify.LikesCount -= 1;
            }

            await this.postsRepo.SaveChangesAsync();
        }

        public async Task IncrementPostLikesCount(string postId)
        {
            var postToModify = this.postsRepo.All().FirstOrDefault(x => x.Id == postId);

            if (postToModify != null)
            {
                postToModify.LikesCount += 1;
            }

            await this.postsRepo.SaveChangesAsync();
        }

        public Task<bool> RemoveUserFromPostLikes(string postId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
