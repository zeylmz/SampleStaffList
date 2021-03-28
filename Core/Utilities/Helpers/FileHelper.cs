using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {


            var sourcePath = file.FileName;

            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(250, 250));
            image.Save(sourcePath);

            var result = newPath(file);
            File.Move(sourcePath, result.newPath);
            return result.Path2;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
            return new SuccessResult();
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result.newPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result.Path2;
        }

        public static (string newPath, string Path2) newPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string path = Environment.CurrentDirectory + @"\wwwroot\Images";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + fileExtension;
            string result = $@"{path}\{newPath}";
            return (result, $"\\Images\\{newPath}");
        }
    }
}
