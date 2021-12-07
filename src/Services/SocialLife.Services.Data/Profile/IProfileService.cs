namespace SocialLife.Services.Data.Profile
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using SocialLife.Web.ViewModels.InputModels;

    public interface IProfileService
    {
        public Task UpdateUserInfoAsync(UpdateProfileInputModel inputModel, string profileId, string profilePic);

        public Task UpdateUserAboutAsync(string user, string aboutDesc);

        public Task RemoveUserProfilePictureAsync(string userId);

        public Task UpdateUserCoverPhotoAsync(string userId, UpdateCoverPhotoInputModel inputModel);

    }
}
