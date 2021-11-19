using SocialLife.Data.Models;
using SocialLife.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialLife.Web.ViewModels.Posts
{
    public class UserPostViewModel : IMapFrom<Post>
    {
        public string Id { get; set; }

        public int LikesCount { get; set; }

        public string TextContent { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
