namespace prosigliere_coding_challenge.Domain.Entities
{
    public class Comment : Entity
    {
        public Comment(string content) => Content = content;
        public string Content { get; init; }

        public BlogPost BlogPost { get; init; }

        public Guid BlogPostId { get; init; }

        public  DateTime CreatedAt { get; init; } = DateTime.Now;

    }
}