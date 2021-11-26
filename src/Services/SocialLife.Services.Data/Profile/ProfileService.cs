﻿namespace SocialLife.Services.Data.Profile
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
                user.ProfilePictureUrl = profilePic;

                await this.userRepo.SaveChangesAsync();
            }
        }
    }
}