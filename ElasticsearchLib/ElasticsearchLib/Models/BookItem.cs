
namespace ElasticsearchLib.Models
{
    public class BookItem
    {
        public string Uid { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        ///
        /// Физическое место хранения книги
        ///
        public string Shelf { get; set; }
    }
}
