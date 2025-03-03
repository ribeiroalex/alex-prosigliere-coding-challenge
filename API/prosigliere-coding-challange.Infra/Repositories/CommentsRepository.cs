using Microsoft.EntityFrameworkCore;
using prosigliere_coding_challange.Infra.Contexts;
using prosigliere_coding_challenge.Domain.Entities;
using prosigliere_coding_challenge.Domain.Queries;
using prosigliere_coding_challenge.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challange.Infra.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        public CommentsRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        private readonly DataContext _dataContext;
        public async Task<IEnumerable<Comment>> GetAll()
        {
            var comments = await _dataContext.Comments.AsNoTracking().OrderBy(x => x.CreatedAt).ToListAsync();
            return comments.AsEnumerable();
        }

        public async Task<bool> Add(Comment comment)
        {
            _dataContext.Comments.Add(comment);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Comment> GetById(Guid id)
        {
            return await _dataContext.Comments.Where(CommentQueries.GetById(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Comment>> GetByPostId(Guid id)
        {
            return await _dataContext.Comments.AsNoTracking().Where(CommentQueries.GetByPostId(id)).OrderBy(x => x.CreatedAt).ToListAsync();
        }
    }
}
