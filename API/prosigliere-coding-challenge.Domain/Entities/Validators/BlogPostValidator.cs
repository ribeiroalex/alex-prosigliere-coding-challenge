using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Entities.Validators
{
    public class BlogPostValidator : AbstractValidator<BlogPost>
    {
        public BlogPostValidator()
        {
                RuleFor(x => x.Title).NotEmpty()
                    .WithMessage("Title is required")
                    .MaximumLength(100)
                    .WithMessage("Title must have a maximum of 100 characters");

            RuleFor(x => x.Content).NotEmpty()
                .MaximumLength(700)
                .WithMessage("Content must have a maximum of 700 characters");

        }
    }
}
