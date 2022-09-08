using Blog.Entities;

namespace Blog.Data
{
    public interface IBlogService
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post> GetPostsByIdAsync(int? Id);
        Task<Post> AddPost(Post post);
        Task<IEnumerable<Post>> GetPostsByUserAsync(string UserId);
        Task<IEnumerable<Post>> GetSortedPostsByUserAsync(string UserId);
    }
}
