namespace SocialLife.Services.Data.Profile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SocialLife.Data.Common.Repositories;
    using SocialLife.Data.Models;
    using SocialLife.Web.ViewModels.InputModels;

    public class ProfileService : IProfileService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;

        public ProfileService(IDeletableEntityRepository<ApplicationUser> userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task RemoveUserProfilePictureAsync(string userId)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                user.ProfilePictureUrl = null;
            }

            await this.userRepo.SaveChangesAsync();
        }

        public async Task UpdateUserCoverPhotoAsync(string userId, UpdateCoverPhotoInputModel inputModel)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                user.CoverPhotoUrl = inputModel.CoverPhoto.FileName;
            }

            await this.userRepo.SaveChangesAsync();
        }

        public async Task UpdateUserAboutAsync(string userId, string aboutDesc)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                user.AboutDescription = aboutDesc;
            }

            await this.userRepo.SaveChangesAsync();
        }

        public async Task UpdateUserInfoAsync(UpdateProfileInputModel inputModel, string profileId, string profilePic)
        {
            var user = this.userRepo.All().FirstOrDefault(x => x.Id == profileId);

            if (user != null)
            {
                user.FirstName = inputModel.FirstName;
                user.LastName = inputModel.LastName;
                user.Country = inputModel.Country;
                user.Region = inputModel.Region;
                user.City = inputModel.City;
                user.PostalCode = inputModel.PostalCode;
                user.PhoneNumber = inputModel.PhoneNumber;
                user.Address = inputModel.Address;

                if (profilePic != string.Empty)
                {
                    user.ProfilePictureUrl = profilePic;
                }

                await this.userRepo.SaveChangesAsync();
            }
        }
    }
}
