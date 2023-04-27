using MediatR;
using MinimalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Application.Posts.Commands
{
    public class CreatePost:IRequest<Post>
    {
        public string PostContent { get; set; }
    }
}
