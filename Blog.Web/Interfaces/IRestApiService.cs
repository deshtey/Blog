using Blog.Entities;

namespace Blog.Web.Interfaces
{
    public interface IRestApiService
    {
        Task FetchOldPosts(string endpoint);
    }
}
