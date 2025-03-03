using prosigliere_coding_challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Queries
{
    public class CommentQueries
    {
        public static Expression<Func<Comment, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Comment, bool>> GetByPostId(Guid id)
        {
            return x => x.BlogPostId == id;
        }
    }
}
