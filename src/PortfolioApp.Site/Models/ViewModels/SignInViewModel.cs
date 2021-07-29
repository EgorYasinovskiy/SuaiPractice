using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Site.Models.ViewModels
{
	public class SignInViewModel
	{
		[Required(ErrorMessage = "Адрес электронной почты - обязательное поле")]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Адрес электронной почты")]
		[EmailAddress(ErrorMessage = "Введенный адрес электронной почты некорректен")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Укажите пароль")]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }
		
		[Display(Name = "Не выходить")]
		public bool RememberMe { get; set; }

		public string ReturnURL { get; set; }
	}
}
