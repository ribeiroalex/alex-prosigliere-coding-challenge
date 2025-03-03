using prosigliere_coding_challenge.Domain.Commands.Contracts;
using prosigliere_coding_challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Commands
{
    public class CreateCommentCommand : ICommand
    {
        public string Content { get; set; }

        public Guid BlogPostId { get; set; }
    }
}
