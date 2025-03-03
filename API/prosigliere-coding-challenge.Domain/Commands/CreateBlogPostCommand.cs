using prosigliere_coding_challenge.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Commands
{
    public class CreateBlogPostCommand : ICommand
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
    }
}
