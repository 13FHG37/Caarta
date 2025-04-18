﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Caarta.Services
{
    public static class FileUpload
    {
        public static async Task<string> UploadAsync(IFormFile picture, string root)
        {
            var extension = Path.GetExtension(picture.FileName);
            var name = Guid.NewGuid().ToString();
            var newFileName = $"{name}{extension}";
            var filePath = Path.Combine(root, "uploads", newFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await picture.CopyToAsync(stream);
            }
            return newFileName;
        }
    }
}
