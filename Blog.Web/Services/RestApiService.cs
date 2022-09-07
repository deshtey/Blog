using Blog.Data;
using Blog.Entities;
using Blog.Web.Data;
using Blog.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Services
{
 
    public class RestApiService : IRestApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;
        public RestApiService(HttpClient httpClient, ApplicationDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }
        public async Task FetchOldPosts(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode == true)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<RestApiRes>();
                    //Return immediately if no articles returned                   
                    if (apiResponse.Count == 0) return;
                    //Bulk insert??
                    foreach (var article in apiResponse.Articles)
                    {
                        var post = new Post
                        {
                            PublishedAt = article.PublishedAt,
                            Title = article.Title,
                            Description = article.Description,
                            AuthorId = "aa6a5495-b191-4567-929a-4e9d9c7f492b"
                        };
                        _context.Add(post);
                    }
                    var complete = await _context.SaveChangesAsync();  
                    
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        Task IRestApiService.FetchOldPosts(string endpoint)
        {
            throw new NotImplementedException();
        }
    }
}
