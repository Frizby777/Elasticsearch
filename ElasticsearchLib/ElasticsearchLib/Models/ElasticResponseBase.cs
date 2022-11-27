using System.Net;

namespace ElasticsearchLib.Models
{
    public class ElasticResponseBase
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
