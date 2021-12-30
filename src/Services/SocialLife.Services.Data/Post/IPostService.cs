using SocialLife.Web.ViewModels.InputModels;
using SocialLife.Web.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialLife.Services.Data
{
  public interface IPostService
    {
        public Task<string> CreatePostAsync(CreatePostInputModel model, string authorId);

        public IEnumerable<T> GetAllUserPosts<T>(string userId);

        public Task<bool> DeleteUserPostAsyns(string postId, string userId);

        public Task<bool> EditUserPostAsync(UserPostViewModel updatedPost, string userId);
    }
}
