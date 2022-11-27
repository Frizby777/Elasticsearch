
namespace ElasticsearchLib.Models
{
    public class SearchItemRequest: ElasticRequestBase
    {
        /// <summary>
        /// Поисковый запрос
        /// </summary>
        public string Query { get; set; }
    }
}
