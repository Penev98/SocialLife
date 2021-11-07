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
    public class UserLikedPostConfiguration : IEntityTypeConfiguration<UserLikedPost>
    {
        public void Configure(EntityTypeBuilder<UserLikedPost> builder)
        {
            builder
               .HasKey(x => new { x.UserId, x.LikedPostId });

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.LikedPosts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.LikedPost)
                .WithMany(x => x.LikedByUsers)
                .HasForeignKey(x => x.LikedPostId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
