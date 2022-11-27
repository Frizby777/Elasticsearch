using ElasticsearchLib;
using ElasticsearchLib.Models;
using System.Net;

namespace ElasticUnitTest
{
    [TestClass]
    public class ClientTests
    {
        private const string host = "http://localhost:9200";
        private const string login = "admin";
        private const string password = "password";
        private readonly ElasticsearchClient client;

        public ClientTests()
        {
            try
            {
                client = new ElasticsearchClient(host, login, password);
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
                throw;
            }
        }

        [TestMethod]
        public async Task IndexAsync()
        {
            var response = await client.IndexItemAsync(new IndexItemRequest()
            {
                BookItem = new BookItem()
                {
                    Uid = "1",
                    Author = "Anthony",
                    Title = "A Clockwork Orange"
                }
            });
        }

        [TestMethod]
        public async Task SearchAsync()
        {
            var response = await client.SearchItemAsync(new SearchItemRequest()
            {
                Query = "A Clockwork Orange"
            });

          //  Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            var delete = await client.DeleteAsync("1");
        }


    }
}