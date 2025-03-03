using prosigliere_coding_challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Queries
{
    public class BlogPostQueries
    {
        public static Expression<Func<BlogPost, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
