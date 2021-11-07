﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SocialLife.Data.Models
{
  public class UserLikedPost
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string LikedPostId { get; set; }

        public virtual Post LikedPost { get; set; }
    }
}
