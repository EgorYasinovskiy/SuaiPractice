using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Site.Models.ViewModels
{
	public class SignInViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Адрес электронной почты")]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }
	}
}
