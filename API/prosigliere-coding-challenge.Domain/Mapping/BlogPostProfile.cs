using AutoMapper;
using prosigliere_coding_challenge.Domain.Commands;
using prosigliere_coding_challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Mapping
{
    public class BlogPostProfile : Profile
    {
        public BlogPostProfile() 
        { 
            CreateMap<CreateBlogPostCommand, BlogPost>();
        }
    }
}
