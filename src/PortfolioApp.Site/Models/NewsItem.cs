﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Site.Models
{
	public class NewsItem
	{
		[Key]
		public Guid Id { get; set; }
		public virtual List<Picture> Pictures { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime Created { get; set; }
	}
}
