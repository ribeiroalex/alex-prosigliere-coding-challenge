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
    public class CommentsHandler : ICommandHandler<CreateCommentCommand>
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IBlogPostsRepository _blogPostsRepository;
        private readonly IValidator<Comment> _validator;
        private readonly IMapper _mapper;

        public CommentsHandler(ICommentsRepository commentsRepository, IBlogPostsRepository blogPostsRepository,IValidator<Comment> validator, IMapper mapper)
        {
            _commentsRepository = commentsRepository;
            _validator = validator;
            _mapper = mapper;
            _blogPostsRepository = blogPostsRepository;
        }

        public async Task<ICommandResult> Handle(CreateCommentCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var comment = _mapper.Map<Comment>(command);
            var validationResult = _validator.Validate(comment);
            if (!validationResult.IsValid)
                return new GenericCommandResult(false, "Error Creating comment", validationResult.Errors);

            var existingPost = await _blogPostsRepository.GetById(command.BlogPostId);
            if (existingPost == null)
                return new GenericCommandResult(false, "Post not found", string.Empty);

            await _commentsRepository.Add(comment);

            return new GenericCommandResult(true, "Post Created", comment.Id);
        }
    }
}
