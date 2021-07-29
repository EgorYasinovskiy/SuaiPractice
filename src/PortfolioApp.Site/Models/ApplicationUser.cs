using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;

namespace PortfolioApp.Site.Models
{
	public class ApplicationUser : IdentityUser
	{
		public virtual ICollection<Post> Posts { get; set; }
		public virtual ICollection<Post> Liked { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
	}
}
