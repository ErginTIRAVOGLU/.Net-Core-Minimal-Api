using MediatR;
using MinimalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Application.Posts.Commands
{
    public class UpdatePost : IRequest<Post>
    {
        public int PostId { get; set; }
        public string PostContent { get; set; }
    }
}
