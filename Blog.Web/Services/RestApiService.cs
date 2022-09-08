using Blog.Data;
using Blog.Entities;
using Blog.Web.Data;
using Blog.Web.Models;
namespace Blog.Web.Services
{
 
    public class RestApiService : IRestApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;
        //private readonly Logger<RestApiService> _logger;

        public RestApiService(HttpClient httpClient, ApplicationDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
            //_logger = logger;
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
                    //Insert All posts using the system created admin login
                    foreach (var article in apiResponse.Articles)
                    {
                        var post = new Post
                        {
                            PublishedAt = article.PublishedAt,
                            Title = article.Title,
                            Description = article.Description,
                            AuthorId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7"
                        };
                        _context.Add(post);
                    }
                    var complete = await _context.SaveChangesAsync();  
                    
                }

            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);
            }


        }

        Task IRestApiService.FetchOldPosts(string endpoint)
        {
            throw new NotImplementedException();
        }
    }
}
