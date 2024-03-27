using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SideProject.Data;
using SideProject.Models.Entities;

namespace SideProject.Service
{
    public interface IDataService
    {
        public Task UploadImage(IFormFile file, string user, fileFormat fileFormat);
        public Task<Image> DownloadImage(int Id);
        public Task<List<Image>> Images(string user);
    }
    public class DataService : IDataService
    {
        private readonly AplicationDbContext _context;
        //public readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _iWebHostEnvironment;

        public DataService(AplicationDbContext context/*,Microsoft.AspNetCore.Hosting.IWebHostEnvironment iWebHostEnvironment*/)
        {
            _context = context;
            //_iWebHostEnvironment = iWebHostEnvironment;
        }

        /*public void UploadImage(IFormFile file, Microsoft.AspNetCore.Hosting.IWebHostEnvironment iWebHostEnvironment)
        {
            string fileName = $"{_iWebHostEnvironment.WebRootPath}\\files\\{file.FileName}";

            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }*/

        public async Task UploadImage(IFormFile file, string user, fileFormat fileFormat)
        {
            Image image = new Image();

            image.user = user;
            image.fileFormat = fileFormat;

            if(file != null)
            {
                if(file.Length > 0 /*&& file.Length < 300000*/)
                {
                    using(var target  = new MemoryStream())
                    {
                        file.CopyTo(target);
                        image.image = target.ToArray();
                    }

                    await _context.images.AddAsync(image);
                    await _context.SaveChangesAsync();
                }
            }

            //int id = _context.images.FirstOrDefaultAsync(x => x.image == image.image).Result.Id;
            /*Image imageForId = await _context.images.FirstOrDefaultAsync(x => x.image == image.image);

            UploadedDatas uploadedDatas = await _context.uploads.FirstOrDefaultAsync(x => x.username == user);
            if(uploadedDatas.imageIds == null)
            {
                uploadedDatas.imageIds = new List<int> { imageForId.Id };
            }
            else
            {
                uploadedDatas.imageIds.Add(imageForId.Id);
            }

            await _context.uploads.AddAsync(uploadedDatas);
            await _context.SaveChangesAsync();*/
        }

        public async Task<Image> DownloadImage(int Id)
        {
            var image = await _context.images.FirstOrDefaultAsync(x => x.Id == Id);
            if(image == null)
            {
                return null;
            }
            return image;
        }

        public async Task<List<Image>> Images(string user)
        {
            return _context.images.Where(x => x.user == user).ToList();
        }
    }
}
