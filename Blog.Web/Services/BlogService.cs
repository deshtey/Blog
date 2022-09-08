using Blog.Data;
using Blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;
        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Post> AddPost(Post post)
        {             
            _context.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _context.Posts
                .Include(p=>p.Author)
                .ToListAsync();      
        }

        public async Task<Post> GetPostsByIdAsync(int? Id)
        {
            var post = await _context
                .Posts
                  .Include(p => p.Author)
                .Where(p => p.Id == Id)              
                .FirstOrDefaultAsync();
            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsByUserAsync(string UserId)
        {
            //Filter posts by the userId
            var posts = await _context
                .Posts
                .Where(p=>p.AuthorId==UserId)
                .ToListAsync();
            return posts;
        }

        public async Task<IEnumerable<Post>> GetSortedPostsByUserAsync(string UserId)
        {
            //Filter posts by the userId
            var posts = await _context
                .Posts
                .Where(p => p.AuthorId == UserId)
                .OrderByDescending(p=>p.PublishedAt)
                .ToListAsync();
            return posts;
        }
    }
}
