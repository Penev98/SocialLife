using SocialLife.Web.ViewModels.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialLife.Services.Data.Profile
{
    public interface IProfileService
    {
        public Task UpdateUserInfoAsync(UpdateProfileInputModel inputModel, string profileId, string profilePic);
    }
}
