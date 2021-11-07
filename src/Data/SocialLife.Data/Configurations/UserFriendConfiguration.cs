using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialLife.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLife.Data.Configurations
{
    public class UserFriendConfiguration : IEntityTypeConfiguration<UserFriend>
    {
        public void Configure(EntityTypeBuilder<UserFriend> builder)
        {

            builder
                .HasKey(x => new { x.UserId, x.UsersFriendId });

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UserFriends)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.
                HasOne(x => x.UsersFriend)
                .WithMany()
                .HasForeignKey(x => x.UsersFriendId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
