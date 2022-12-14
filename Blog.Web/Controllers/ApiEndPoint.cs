using Blog.Web.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class ApiEndPoint : Controller
    {
        private readonly IRestApiService _apiService;
        private readonly IConfiguration _configuration;

        public ApiEndPoint(IRestApiService apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var EndpointURI = _configuration["OldBlogEndpoint"];
            RecurringJob.AddOrUpdate(() => _apiService.FetchOldPosts(EndpointURI), Cron.Minutely);
            return Ok($"Posts Fetched Successfully.");
        }
    }
}
