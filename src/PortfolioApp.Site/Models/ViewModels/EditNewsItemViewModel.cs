using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApp.Site.Models.ViewModels
{
	public class EditNewsItemViewModel : AddNewsItemViewModel
	{
		public Guid Id { get; set; }
	}
}
