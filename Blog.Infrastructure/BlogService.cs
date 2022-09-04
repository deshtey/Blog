using Blog.Domain.Data;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure
{
    public class BlogService : IBlogRepository
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

        public async Task<IEnumerable<Post>> FetchOldPosts(string endpoint)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _context.Posts.Take(1).ToListAsync();
            return posts;   
        }

        public async Task<Post> GetPostsByIdAsync(int? Id)
        {
            var post = await _context.Posts.Where(p => p.Id == Id).FirstOrDefaultAsync();
            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsByUserAsync(string UserId)
        {
            var posts = await _context.Posts.Take(1).ToListAsync();
            return posts;
        }
    }
}
