using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Site.Models
{
	public class Picture
	{
		[Key]
		public Guid Id { get; set; }
		public string PicturePath { get; set; }
		public virtual List<NewsItem> News { get; set; }
		public virtual List<Post> Posts { get; set; }
	}
}
