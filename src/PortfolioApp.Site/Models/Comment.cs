using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Site.Models
{
	public class Comment
	{
		[Key]
		public Guid Id { get; set; }
		public Guid PostId { get; set; }
		public virtual Post Post { get; set; }
		public string UserID { get; set; }
		public virtual ApplicationUser User { get; set; }
		public string Text { get; set; }
		public DateTime Created { get; set; }
	}
}
