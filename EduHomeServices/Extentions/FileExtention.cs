using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;

namespace EduHomeServices.Extentions
{
    public static class FileExtention
    {
        public static string SaveFile(this IFormFile file, string rootPath, string folder)
        {
            string RootPath = Path.Combine(rootPath, folder);
            string FileName = Guid.NewGuid().ToString() + file.FileName;
            string FullPath = Path.Combine(RootPath, FileName);
            using (FileStream fileStream = new FileStream(FullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return FileName;
        }

        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }
        public static bool IsSizeOk(this IFormFile file, int mb)
        {
            double length = ((double)(file.Length / 1024) / 1024);
            return length > mb;
        }

        public static void RemoveFile(string webRootPath, string folder, string filename)
        {
            File.Delete(Path.Combine(webRootPath, folder, filename));
        }

    }
}

