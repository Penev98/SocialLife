namespace SocialLife.Services.Data.Post
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SocialLife.Data.Common.Repositories;
    using SocialLife.Data.Models;
    using SocialLife.Services.Mapping;
    using SocialLife.Web.ViewModels.InputModels;
    using SocialLife.Web.ViewModels.Posts;

    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postsRepo;

        public PostService(IDeletableEntityRepository<Post> postsRepo)
        {
            this.postsRepo = postsRepo;
        }

        public async Task CreatePostAsync(CreatePostInputModel model, string authorId)
        {
            Post postToCreate = new Post()
            {
                TextContent = model.Content,
                LikesCount = 0,
                AuthorId = authorId,
            };

            await this.postsRepo.AddAsync(postToCreate);
            await this.postsRepo.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserPostAsyns(string postId, string userId)
        {
            var userPosts = this.postsRepo.AllAsNoTracking().Where(x => x.AuthorId == userId).ToList();

            if (userPosts != null)
            {
                var postToDelete = userPosts.FirstOrDefault(x => x.Id == postId);

                if (postToDelete != null)
                {
                    this.postsRepo.HardDelete(postToDelete);
                    await this.postsRepo.SaveChangesAsync();

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> EditUserPostAsync(UserPostViewModel updatedPost, string userId)
        {
            var userPosts = this.postsRepo.All().Where(x => x.AuthorId == userId).ToList();

            if (userPosts != null)
            {
                var postToEdit = userPosts.FirstOrDefault(x => x.Id == updatedPost.Id);

                if (postToEdit != null)
                {
                    postToEdit.TextContent = updatedPost.TextContent;

                    await this.postsRepo.SaveChangesAsync();

                    return true;
                }
            }

            return false;
        }

        public IEnumerable<T> GetAllUserPosts<T>(string userId)
        {
            return this.postsRepo.AllAsNoTracking()
                .Where(x => x.AuthorId == userId)
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToList();
        }
    }
}
