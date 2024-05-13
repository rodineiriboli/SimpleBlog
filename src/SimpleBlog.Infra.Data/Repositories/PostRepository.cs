using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Entities;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Infra.Data.Context;

namespace SimpleBlog.Infra.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SimpleBlogConext _context;

        public PostRepository(SimpleBlogConext context)
        {
            _context = context;
        }

        public async Task<Posts> AddPost(Posts post)
        {
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<IEnumerable<Posts>> GetAll()
        {
            var posts = await _context.Posts.ToListAsync();

            return posts;
        }

        public async Task<Posts> GetById(Guid id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            return post;
        }

        public async Task<Posts> UpdatePost(Posts post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();

            return post;
        }
    }
}