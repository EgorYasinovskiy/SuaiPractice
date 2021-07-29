using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

namespace PortfolioApp.Site.Models.ViewModels
{
	public class AddNewsItemViewModel
	{
		[Required(ErrorMessage = "Заголовок не указан")]
		[Display(Name ="Заголовок")]
		[DataType(DataType.Text)]
		[MaxLength(64,ErrorMessage = "Длина заголовка должна быть не больше 64 символов")]
		public string Title { get; set; }

		[Required]
		[Display(Name = "Текст новости")]
		[DataType(DataType.MultilineText)]
		public string Text { get; set; }

		[Display(Name = "Изображения")]
		[DataType(DataType.Upload)]
		public List<IFormFile> Pictures { get; set; }

		

	}
}
