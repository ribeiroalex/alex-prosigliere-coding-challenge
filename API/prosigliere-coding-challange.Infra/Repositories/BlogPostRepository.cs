using Microsoft.EntityFrameworkCore;
using prosigliere_coding_challange.Infra.Contexts;
using prosigliere_coding_challenge.Domain.Entities;
using prosigliere_coding_challenge.Domain.Queries;
using prosigliere_coding_challenge.Domain.Repositories;

namespace prosigliere_coding_challange.Infra.Repositories
{
    public class BlogPostRepository : IBlogPostsRepository
    {
        public BlogPostRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        private readonly DataContext _dataContext;
        public async Task<IEnumerable<BlogPost>> GetAll()
        {
            var blogPosts = await _dataContext.BlogPosts.AsNoTracking().OrderBy(x => x.CreatedAt).ToListAsync();
            return blogPosts.AsEnumerable();
        }

        public async Task<bool> Add(BlogPost blogPost)
        {
            _dataContext.BlogPosts.Add(blogPost);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<BlogPost> GetById(Guid id)
        {
            return await _dataContext.BlogPosts.Where(BlogPostQueries.GetById(id)).FirstOrDefaultAsync();
        }
    }
}
