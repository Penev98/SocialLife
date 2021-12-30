namespace SocialLife.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using SocialLife.Data.Models;
    using SocialLife.Services.Mapping;
    using SocialLife.Web.ViewModels.Attachments;

    public class UserPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public int LikesCount { get; set; }

        public string TextContent { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<AttachmentViewModel> Attachments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, UserPostViewModel>()
                .ForMember(x => x.Attachments, opt => opt.MapFrom(x => x.Attachments.Select(x => new AttachmentViewModel()
                {
                    Url = x.Url,
                    FileExtension = x.FileExtension,
                })));
        }
    }
}
