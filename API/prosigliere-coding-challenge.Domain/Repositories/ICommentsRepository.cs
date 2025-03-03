using prosigliere_coding_challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Repositories
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comment>> GetAll();
        Task<Comment> GetById(Guid id);

        Task<IEnumerable<Comment>> GetByPostId(Guid id);

        Task<bool> Add(Comment blogPost);
    }
}
