using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using PortfolioApp.Site.Models;
using PortfolioApp.Site.Models.ViewModels;

namespace PortfolioApp.Site.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		
		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel model)
		{
			if(ModelState.IsValid)
			{
				ApplicationUser user = new ApplicationUser() { Email = model.Email, UserName = model.Email };
				var result = await _userManager.CreateAsync(user, model.Password);
				if(result.Succeeded)
				{
					await _signInManager.SignInAsync(user, false);
					return RedirectToAction("Index", "Home");
				}
				foreach(var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel model)
		{
			if(ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
				if(result.Succeeded)
				{
					if(!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
					{
						return Redirect(model.ReturnURL);
					}
					else
					{
						return RedirectToAction("Index", "Home");
					}
				}
				ModelState.AddModelError("Ошибка авторизации", "Неверный логин или пароль");
			}
			return View(model);
		}
	}
}