using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Site.Models
{
	public class NewsItem
	{
		[Key]
		public Guid Id { get; set; }
		public Guid PictureId { get; set; }
		public virtual Picture Picture { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime Created { get; set; }
	}
}
