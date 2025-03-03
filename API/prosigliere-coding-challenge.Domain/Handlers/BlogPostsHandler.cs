using AutoMapper;
using FluentValidation;
using prosigliere_coding_challenge.Domain.Commands;
using prosigliere_coding_challenge.Domain.Commands.Contracts;
using prosigliere_coding_challenge.Domain.Entities;
using prosigliere_coding_challenge.Domain.Handlers.Contracts;
using prosigliere_coding_challenge.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Handlers
{
    public class BlogPostsHandler : ICommandHandler<CreateBlogPostCommand>
    {
        private readonly IBlogPostsRepository _blogPostRepository;
        private readonly IValidator<BlogPost> _validator;
        private readonly IMapper _mapper;

        public BlogPostsHandler(IValidator<BlogPost> validator, IMapper mapper, IBlogPostsRepository blogPostRepositor)
        {
            _validator = validator;
            _mapper = mapper;
            _blogPostRepository = blogPostRepositor;
        }

        public async Task<ICommandResult> Handle(CreateBlogPostCommand command)
        {
            var blogPost = _mapper.Map<BlogPost>(command);
            var validationResult = _validator.Validate(blogPost);
            if(!validationResult.IsValid)
                return new GenericCommandResult(false, "Error Creating post", validationResult.Errors);

            await _blogPostRepository.Add(blogPost);

            return new GenericCommandResult(true, "Post Created", blogPost.Id);
        }
    }
}
