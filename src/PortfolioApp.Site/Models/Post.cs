using System;
using System.Collections.Generic;

namespace PortfolioApp.Site.Models
{
	public class Post : NewsItem
	{
		public virtual ICollection<ApplicationUser> LikedUsers { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public string AuthorID { get; set; }
		public virtual ApplicationUser Author { get; set; }
	}
}
