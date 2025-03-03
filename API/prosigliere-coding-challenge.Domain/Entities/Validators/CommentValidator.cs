using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Entities.Validators
{
    public class CommentValidator :AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Content).NotEmpty()
                .WithMessage("Comment Content is required")
                .MaximumLength(700)
                .WithMessage("Content must have a maximum of 700 characters.");

            RuleFor(x => x.BlogPostId).NotEmpty()
                .WithMessage("Comment must belong to an existing Post.");

        }
    }
}
