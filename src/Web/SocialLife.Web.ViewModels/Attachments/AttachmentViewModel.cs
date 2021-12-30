namespace SocialLife.Web.ViewModels.Attachments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SocialLife.Data.Models;
    using SocialLife.Services.Mapping;

    public class AttachmentViewModel : IMapFrom<Attachment>
    {
        public string Url { get; set; }

        public string FileExtension { get; set; }
    }
}
