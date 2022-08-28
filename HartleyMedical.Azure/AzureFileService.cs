using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using HartleyMedical.Application.Common.Helpers;
using HartleyMedical.Application.Common.Settings;
using HartleyMedical.Application.ExternalDependencies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Azure
{
    public class AzureFileService : IFileService
    {
        private AzureSettings _azureSettings;
        private BlobServiceClient _blobServiceClient;
        public AzureFileService(IOptions<AzureSettings> azureSettings)
        {
            _azureSettings = azureSettings.Value;
            _blobServiceClient = new BlobServiceClient(azureSettings.Value.AccountConnectionString);
        }

        public string GetFile(string name, string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobName);
            var blobClient = containerClient.GetBlobClient(name);

            var blobDownlaodInfo = blobClient.Download();
            //return new BlobInfo(blobDownlaodInfo.Value.Content, blobDownlaodInfo.Value.ContentType);
            return "";
        }

        public IEnumerable<string> GetAllFiles()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("deacertificates");

            var items = new List<string>();

            foreach (var blobItem in containerClient.GetBlobs())
            {
                items.Add(blobItem.Name);
            }

            return items;
        }

        public string UploadFile(IFormFile file, string blobName)
        {
            var filename = "image1.jpg";
            //var filePath = @"D:\Images\image1.jpg";
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobName);
            var blobClient = containerClient.GetBlobClient(file.Name);

            //var filestream = File.OpenRead(file.Name);
            //blobClient.Upload(filestream);

            var bytes = Encoding.UTF8.GetBytes(file.ContentDisposition);
            var memoryStream = new MemoryStream(bytes);
            var blobcontenctInfo = blobClient.Upload(memoryStream, new BlobHttpHeaders { ContentType = filename.GetContentType() });
            //var blobcontenctInfo = blobClient.Upload(filePath, new BlobHttpHeaders { ContentType = filePath.GetContentType() });

            return "";
        }
    }
}
