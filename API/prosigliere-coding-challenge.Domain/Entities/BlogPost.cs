using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Entities
{
    public class BlogPost : Entity
    {

        [SetsRequiredMembers]
        public BlogPost(string title, string content) =>
        (Title, Content) = (title, content);

        public required string Title { get; init; }

        public required string Content { get; init; }

        public DateTime CreatedAt { get; init; } = DateTime.Now;

        private readonly List<Comment> _comments = new();
        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    }
}
