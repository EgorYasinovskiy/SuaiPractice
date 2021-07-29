﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PortfolioApp.Site.Models
{
    public class ApplicationUser :IdentityUser
    {
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Post> Liked { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
