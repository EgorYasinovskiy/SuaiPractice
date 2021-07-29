using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Site.Models
{
	public class Post
	{
		[Key]
		public Guid Id { get; set; }
		public virtual ICollection<Picture> Pictures { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime Created { get; set; }
		public virtual ICollection<ApplicationUser> LikedUsers { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public string AuthorID { get; set; }
		public virtual ApplicationUser Author { get; set; }
	}
}
