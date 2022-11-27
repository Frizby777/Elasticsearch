using ElasticsearchLib.Models;
using Nest;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ElasticsearchLib
{
    public class ElasticsearchClient
    {
        #region Fields
        private readonly ElasticClient client;
        private const string indexName = "book";
        #endregion

        #region Constructor
        public ElasticsearchClient(
            string host,
            string login,
            string password)
        {
            var settings = new ConnectionSettings(new Uri(host));
            settings.DefaultIndex(indexName);
            settings.BasicAuthentication(login, password);
            client = new ElasticClient(settings);
        }


        #endregion

        #region Public
        public async Task<IndexItemResponse> IndexItemAsync(IndexItemRequest request)
        {
            var response = new IndexItemResponse();
            var indexResponse = await client.IndexDocumentAsync(request);
            SetStatusCodeEndError(response, indexResponse);
            return response;
        }
        
        public async Task<SearchItemResponse> SearchItemAsync(SearchItemRequest request)
        {
            return new SearchItemResponse();
        }

        public async Task<IEnumerable<BookItem>> SearchAsync(string query)
        {
            var searchResponse = await client.SearchAsync<BookItem>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                     .Match(m => m
                        .Field(f => f.Title)
                        .Query(query)
                     )
                )
            );

            return searchResponse.Documents;
        }

        public async Task<DeleteResponse> DeleteAsync(string id)
        {
            var deleteRequest = new DeleteRequest(indexName, id);
            return await client.DeleteAsync(deleteRequest);

        }



        #endregion

        #region Private

        private HttpStatusCode GetHttpStatusCode(ResponseBase response)
        {
            return (HttpStatusCode)(response?.ApiCall?.HttpStatusCode ?? (int)HttpStatusCode.InternalServerError);
        }

        private void SetStatusCodeEndError(IndexItemResponse response, IndexResponse indexResponse)
        {
            response.StatusCode = GetHttpStatusCode(indexResponse);
            response.Message = indexResponse.ApiCall.OriginalException?.ToString();
        }

        #endregion



    }
}