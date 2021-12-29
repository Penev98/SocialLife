namespace SocialLife.Services.Data.Post
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SocialLife.Data;
    using SocialLife.Data.Common.Repositories;
    using SocialLife.Data.Models;

    public class PostLikesService : IPostLikesService
    {
        private readonly IDeletableEntityRepository<Post> postsRepo;
        private readonly ApplicationDbContext dbContext;

        public PostLikesService(IDeletableEntityRepository<Post> postsRepo, ApplicationDbContext dbContext)
        {
            this.postsRepo = postsRepo;
            this.dbContext = dbContext;
        }

        public async Task AddUserToPostLikesAsync(string postId, string userId)
        {
            var userLikedPost = new UserLikedPost()
            {
                LikedPostId = postId,
                UserId = userId,
            };

            await this.dbContext.UserLikedPosts.AddAsync(userLikedPost);
            await this.dbContext.SaveChangesAsync();
        }

        public bool CheckUserPostLike(string postId, string userId)
        {
            var likedPosts = this.dbContext.UserLikedPosts.Where(x => x.UserId == userId).ToList();
            return likedPosts.Any(x => x.LikedPostId == postId);
        }

        public async Task DecrementPostLikesCountAsync(string postId)
        {
            var postToModify = this.postsRepo.All().FirstOrDefault(x => x.Id == postId);

            if (postToModify != null)
            {
                postToModify.LikesCount -= 1;
            }

            await this.postsRepo.SaveChangesAsync();
        }

        public async Task IncrementPostLikesCountAsync(string postId)
        {
            var postToModify = this.postsRepo.All().FirstOrDefault(x => x.Id == postId);

            if (postToModify != null)
            {
                postToModify.LikesCount += 1;
            }

            await this.postsRepo.SaveChangesAsync();
        }

        public async Task<int> PostLikesCount(string postId)
        {
            var postToCheck = this.postsRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == postId);

            if (postToCheck != null)
            {
                return postToCheck.LikesCount;
            }

            await this.postsRepo.SaveChangesAsync();
            // signal that something went wrong
            return -1;
        }

        public async Task RemoveUserFromPostLikesAsync(string postId, string userId)
        {
            var recordToRemove = this.dbContext.UserLikedPosts.Where(x => x.UserId == userId && x.LikedPostId == postId).FirstOrDefault();

            if (recordToRemove != null)
            {
                this.dbContext.UserLikedPosts.Remove(recordToRemove);
            }

            await this.dbContext.SaveChangesAsync();
        }
    }
}
