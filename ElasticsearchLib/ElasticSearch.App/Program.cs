using ElasticsearchLib;
using ElasticsearchLib.Models;
using ElasticSearch.App.ViewModels;
using OnnlineLibrary.Controllers;
using Nest;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
string host = "http://localhost:9200";
string login = "admin";
string password = "password";
ElasticsearchClient client = new ElasticsearchClient(host, login, password);
BooksController booksController = new BooksController();
ClientBookItem bookItem = new ClientBookItem() {Author="Anthony", Title ="Orange", Uid = "1" };
bookItem.CreateBookItem();

//await client.IndexItemAsync(new IndexItemRequest()
//{
//    BookItem = new BookItem()
//    {
//        Uid = "1",
//        Author = "Anthony",
//        Title = "A Clockwork Orange"
//    }
//});

await client.DeleteAsync("book");


////// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}


//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();
//app.Run();