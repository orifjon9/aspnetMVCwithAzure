using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ps_start2aspnetmvc.Data
{
    public class ImageStore
    {
        CloudBlobClient cloudBlobClient;

        Uri baseUri = new Uri(ConfigurationManager.AppSettings["BSUrl"]);

        public ImageStore()
        {
            cloudBlobClient = new CloudBlobClient(baseUri,
                new StorageCredentials(
                    ConfigurationManager.AppSettings["BSAccount"], 
                    ConfigurationManager.AppSettings["BSKey"]));
        }

        public async Task<string> SaveImage(Stream stream)
        {
            var id = Guid.NewGuid().ToString();
            var container = cloudBlobClient.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(id);
            await blob.UploadFromStreamAsync(stream);

            return id;
        }

        public Uri GetUri(string imageId)
        {
            var container = cloudBlobClient.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(imageId);

            var sasPolicy = new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessStartTime = DateTime.Now.AddMinutes(-5),
                SharedAccessExpiryTime = DateTime.Now.AddMinutes(5)
            };

            var sasToken = blob.GetSharedAccessSignature(sasPolicy);


            return new Uri(baseUri, $"/images/{imageId}{sasToken}");
        }
    }
}