using System.Net;

namespace AspNetCoreWebApp.CloudStorage
{
    public class CloudStorageResponse
    {

        public byte[] Bytes { get; }
        public HttpStatusCode StatusCode { get; }
        public bool IsSuccessStatusCode => StatusCode.Equals(HttpStatusCode.OK);
        public CloudStorageResponse(HttpStatusCode statusCode, byte[] bytes = null)
        {
            Bytes = bytes;
            StatusCode = statusCode;
        }
    }
}
