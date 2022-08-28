using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.ExternalDependencies
{
    public interface IFileService
    {
        string UploadFile(IFormFile file, string blobName);
        string GetFile(string name, string blobName);
        IEnumerable<string> GetAllFiles();
    }
}
