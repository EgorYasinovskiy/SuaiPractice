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
		public FileUploadService(ApplicationDataContext context, IWebHostEnvironment appEnv)
		{
			_context = context;
			_appEnv = appEnv;
			uploadPath = Path.Combine(_appEnv.WebRootPath, "UploadsFiles\\");

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
				string fileName = Path.GetRandomFileName();
				fileName= Path.ChangeExtension(fileName, Path.GetExtension(file.FileName));
				string filePath = Path.Combine(_appEnv.WebRootPath, "UploadsFiles", fileName);
				using (FileStream fs = new FileStream(filePath,FileMode.Create))
				{
					await file.CopyToAsync(fs);
				}
				pic = new Picture() { Id = Guid.NewGuid(), PicturePath = filePath };
				await _context.Pictures.AddAsync(pic);
				pics.Add(pic);
			}
			await _context.SaveChangesAsync();
			return pics;
		}
	}
}
