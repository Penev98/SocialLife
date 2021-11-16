using SocialLife.Web.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialLife.Services.Data
{
  public interface IPostService
    {
        public Task CreatePostAsync(CreatePostInputModel model, string authorId);

        public IEnumerable<T> GetAllUserPosts<T>(string userId);
    }
}
