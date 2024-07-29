using Docker_Compose_Sql_Sample.Data;
using Docker_Compose_Sql_Sample.Entity;
using Microsoft.EntityFrameworkCore;

namespace Docker_Compose_Sql_Sample.Services
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _bLobDbContext;

        public BlogService(ApplicationDbContext bLobDbContext)
        {
            _bLobDbContext = bLobDbContext;
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _bLobDbContext.Blogs.AddAsync(blog);
            await _bLobDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var blog = await _bLobDbContext.Blogs.FirstOrDefaultAsync(p => p.Id == id);
            if (blog != null)
            {
                _bLobDbContext.Blogs.Remove(blog);
                await _bLobDbContext.SaveChangesAsync();
                id = blog.Id;
            }
            return id;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _bLobDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _bLobDbContext.Blogs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            var existingBlog = await _bLobDbContext.Blogs.FirstOrDefaultAsync(p => p.Id == blog.Id);
            if (existingBlog != null)
            {
                existingBlog.Name = blog.Name;
                existingBlog.Description = blog.Description;
                existingBlog.Author = blog.Author;

                await _bLobDbContext.SaveChangesAsync();
            }
            return existingBlog.Id;
        }
    }
}
