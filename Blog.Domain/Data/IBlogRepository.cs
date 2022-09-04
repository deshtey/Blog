using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blog.Domain.Data
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post> GetPostsByIdAsync(int? Id);
        Task<Post> AddPost(Post post);
        Task<IEnumerable<Post>> GetPostsByUserAsync(string UserId);
        Task<IEnumerable<Post>> FetchOldPosts(string endpoint);
    }
}
