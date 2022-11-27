
namespace ElasticsearchLib.Models
{
    public class SearchItemResponse: ElasticResponseBase
    {
        public IEnumerable<BookItem> BookItems { get; set; }
    }
}
