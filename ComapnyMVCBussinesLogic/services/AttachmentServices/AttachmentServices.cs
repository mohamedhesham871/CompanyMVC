using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComapnyMVCBussinesLogic.services.AttachmentServices
{
    public class AttachmentServices : IAttachmentServices
    {
        List<string> _allowedExtensions = [".jpg", ".png" ];

        int MaxSize = 2 * 1024 * 1024; // 2 MB

      

        public string? Upload(IFormFile file,string FolderName)
        {
            // 1- Cheack Extenstion
           
            var Extension = Path.GetExtension(file.FileName);
            if (!_allowedExtensions.Contains(Extension)) return null;

            // 2- Cheack Size
            if(file.Length > MaxSize) return null;

            // 3- Get The Folder Locater Path 
            //wwwroot/Files/Images
            //WWWroot/Files/Videos
            //WWWroot/Files/Pdf

            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", FolderName);

            //4-Make Attachment Unique Using Guid
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            //5-Get The Full Path
            var FullPath = Path.Combine(FolderPath, fileName);//Full path
            // 6-create File  Stream To Copy The File[Umanged]
            using (var stream = new FileStream(FullPath, FileMode.Create))
            
           //7-use Stream to Copy the file
            file.CopyTo(stream);
            //8-Return The File Path
            return fileName;


        }

        public bool Delete(string FilePath)
        {
            if (!File.Exists(FilePath)) return false;
            //Get The Full Path
            else
            {
                File.Delete(FilePath);
                return true;
            }
        }
          
    }
}
