using System;
using System.Collections.Generic;
using System.Text;

namespace SocialLife.Data.Models
{
   public class UserFriend
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UsersFriendId { get; set; }

        public virtual ApplicationUser UsersFriend { get; set; }
    }
}
