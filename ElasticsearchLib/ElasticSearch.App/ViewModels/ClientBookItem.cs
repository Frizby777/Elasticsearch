using ElasticsearchLib.Models; 

namespace ElasticSearch.App.ViewModels
{
    public class ClientBookItem
    {
        public string Uid { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

    }

    public static class ClientBookItemExtensions
    {
       public static BookItem CreateBookItem(this ClientBookItem clientBookItem)
       {
            return new BookItem()
            {
                Uid = clientBookItem.Uid,
                Title = clientBookItem.Title,
                Author = clientBookItem.Author,
            };
       }

        public static ClientBookItem CreateClientBookItem(this BookItem bookItem)
        {
            return new ClientBookItem()
            {
                Uid = bookItem.Uid,
                Title=bookItem.Title,
                Author=bookItem.Author,
            };
        }


    }

}
