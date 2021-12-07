// ReSharper disable VirtualMemberCallInConstructor
namespace SocialLife.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    using SocialLife.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Posts = new HashSet<Post>();
            this.Attachments = new HashSet<Attachment>();
            this.LikedPosts = new HashSet<UserLikedPost>();
            this.UserFriends = new HashSet<UserFriend>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string CoverPhotoUrl { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string Region { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(5)]
        public string PostalCode { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        public string AboutDescription { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<UserLikedPost> LikedPosts { get; set; }

        public virtual ICollection<UserFriend> UserFriends { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
