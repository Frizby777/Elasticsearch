
namespace ElasticsearchLib.Models
{
    public class AuthotizationRequest: ElasticRequestBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
