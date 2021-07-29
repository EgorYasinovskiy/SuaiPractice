using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PortfolioApp.Site.Models;
using PortfolioApp.Site.Models.ViewModels;

namespace PortfolioApp.Site.Controllers
{
	//[Authorize("admin")]
	public class NewsController : Controller
	{

		private readonly FileUploadService _fileService;
		private readonly ApplicationDataContext _context;

		public NewsController(FileUploadService fileUploadService, ApplicationDataContext context)
		{
			_fileService = fileUploadService;
			_context = context;
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddNewsItemViewModel model)
		{
			if (ModelState.IsValid)
			{
				var pics = await _fileService.UploadFilesAsync(model.Pictures);
				var newsItem = new NewsItem()
				{
					Created = DateTime.Now,
					Id = Guid.NewGuid(),
					Text = model.Text,
					Title = model.Title,
					Pictures = pics.ToList()
				};
				await _context.News.AddAsync(newsItem);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index", "Home");
			}
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(Guid id)
		{
			var newsItem = await _context.News.FindAsync(id);
			_context.News.Remove(newsItem);
			await _context.SaveChangesAsync();
			return RedirectToAction("List", "News");
		}
		[HttpGet]
		public IActionResult List()
		{
			return View(_context.News.Include(n=>n.Pictures).ToList());
		}
	}
}
