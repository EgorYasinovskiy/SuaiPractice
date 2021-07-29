using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PortfolioApp.Site.Models
{
	public class FileUploadService
	{
		private readonly ApplicationDataContext _context;
		private readonly IWebHostEnvironment _appEnv;
		private readonly string uploadPath;
		private const string UploadDir = "UploadFiles/";
		public FileUploadService(ApplicationDataContext context, IWebHostEnvironment appEnv)
		{
			_context = context;
			_appEnv = appEnv;
			uploadPath = Path.Combine(_appEnv.WebRootPath, UploadDir);

			if (!Directory.Exists(uploadPath))
			{
				Directory.CreateDirectory(uploadPath);
			}
		}
		public async Task<IEnumerable<Picture>> UploadFilesAsync(IEnumerable<IFormFile> files)
		{
			List<Picture> pics = new List<Picture>();
			foreach(var file in files)
			{
				Picture pic;
				var id = Guid.NewGuid();
				var fileName= Path.ChangeExtension(id.ToString(), Path.GetExtension(file.FileName));
				string filePath = Path.Combine(uploadPath, fileName);
				using (FileStream fs = new FileStream(filePath,FileMode.Create))
				{
					await file.CopyToAsync(fs);
				}
				pic = new Picture() { Id = id, PicturePath = Path.Combine("/",UploadDir,fileName) };
				await _context.Pictures.AddAsync(pic);
				pics.Add(pic);
			}
			await _context.SaveChangesAsync();
			return pics;
		}
	}
}
