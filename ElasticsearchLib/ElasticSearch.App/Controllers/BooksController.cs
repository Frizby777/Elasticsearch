using ElasticsearchLib;
using ElasticsearchLib.Models;
using Microsoft.AspNetCore.Mvc;
using ElasticSearch.App.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace OnnlineLibrary.Controllers
{
    public class BooksController : Controller
    {
        // TODO Перенести в appsetting
        private const string host = "http://localhost:9200";
        private const string login = "admin";
        private const string password = "password";
        private ElasticsearchClient client;

        // TODO Понять как пользоваться Dependency Injection
        //public BooksController(ElascticSearchClient client)
        //{
        //   client = client;
        //}

        public BooksController()
        {
            client = new ElasticsearchClient(host, login, password);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClientBookItem bookItem)
        {

            var result = await client.IndexItemAsync(new IndexItemRequest()
            {
                BookItem = CreateBookItem(bookItem)
            }); ;

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                return BadRequest(result.Message);

            return View();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Serach(string searchText)
        {
            var result = await client.SearchItemAsync(new SearchItemRequest()
            {
                Query = searchText
            });

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                return BadRequest(result.Message);

            var books = result.BookItems.Select(b => b.CreateClientBookItem());
            return Json(books);
        }

        public BookItem CreateBookItem(ClientBookItem clientBookItem)
        {
            return new BookItem()
            {
                Uid = clientBookItem.Uid,
                Title = clientBookItem.Title,
                Author = clientBookItem.Author,
            };
        }
    }
}
