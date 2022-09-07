using Blog.Entities;

namespace Blog.Web.Data
{
    public interface IRestApiService
    {
        Task FetchOldPosts(string endpoint);
    }
}
