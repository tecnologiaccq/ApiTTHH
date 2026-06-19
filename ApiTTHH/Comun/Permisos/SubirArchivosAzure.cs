using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage;

namespace ApiTTHH.Comun.Permisos
{
    public static class SubirArchivosAzure
    {
        public static async Task<string> getUrlAzurePermisos(HttpContent provider, int idColaborador)
        {
            string url = "";
            Stream fileStream = await provider.ReadAsStreamAsync();
            string filename = provider.Headers.ContentDisposition.FileName.Replace('"', ' ').Trim();
            string extension = Path.GetExtension(filename);
            string contentType = provider.Headers.ContentType.MediaType;
            string conecctString = ConfigurationManager.ConnectionStrings["AzureStorageAccountCCQ"].ConnectionString;
            CloudStorageAccount sa = CloudStorageAccount.Parse(conecctString);
            CloudBlobClient bc = sa.CreateCloudBlobClient();
            CloudBlobContainer container = bc.GetContainerReference("ccq");

            CloudBlobDirectory directory = container.GetDirectoryReference("erp/Nomina/SolicitudesPermisos/" + idColaborador);
            try
            {
                BlobRequestOptions requestOptions = new BlobRequestOptions() { RetryPolicy = new NoRetry() };
                container.CreateIfNotExists(requestOptions, null);
                string key = filename;
                CloudBlockBlob b = directory.GetBlockBlobReference(key);
                b.Properties.ContentType = contentType;
                b.UploadFromStream(fileStream);
                url = b.StorageUri.PrimaryUri.AbsoluteUri;
            }
            catch (StorageException ex)
            {
                var message = string.Format(ex.Message);
                throw new Exception(message);
            }
            return url;
        }

        public static List<string> getUrlAzure(string path)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string url = "";
            List<string> results = new List<string>();
            string filename = Path.GetFileName(path);
            string extension = Path.GetExtension(filename);
            string contentType = "application/pdf";//Path. provider.Contents[index].Headers.ContentType.MediaType;
            string conecctString = ConfigurationManager.ConnectionStrings["AzureStorageAccountCCQ"].ConnectionString;
            CloudStorageAccount sa = CloudStorageAccount.Parse(conecctString);
            CloudBlobClient bc = sa.CreateCloudBlobClient();
            CloudBlobContainer container = bc.GetContainerReference("ccq");

            CloudBlobDirectory directory = container.GetDirectoryReference("erp/Nomina/SolicitudesVacaciones");
            try
            {
                BlobRequestOptions requestOptions = new BlobRequestOptions() { RetryPolicy = new NoRetry() };
                container.CreateIfNotExists(requestOptions, null);
                string key = filename;
                CloudBlockBlob b = directory.GetBlockBlobReference(key);
                b.Properties.ContentType = contentType;
                b.UploadFromByteArray(bytes, 0, bytes.Length);
                url = b.StorageUri.PrimaryUri.AbsoluteUri;
                results.Add(url);
                results.Add(Convert.ToBase64String(bytes));
            }
            catch (StorageException ex)
            {
                var message = string.Format(ex.Message);
                throw new Exception(message);
                //return thr;
            }
            return results;
        }


    }
}