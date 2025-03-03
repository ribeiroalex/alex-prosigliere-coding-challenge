using prosigliere_coding_challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Repositories
{
    public interface IBlogPostsRepository
    {
        Task<IEnumerable<BlogPost>> GetAll();
        Task<BlogPost> GetById(Guid id);

        Task<bool> Add(BlogPost blogPost);
    }
}
