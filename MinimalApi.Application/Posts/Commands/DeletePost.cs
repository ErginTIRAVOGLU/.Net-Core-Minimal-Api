using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Application.Posts.Commands
{
    public class DeletePost : IRequest
    {
        public int PostId { get; set; }
    }
}
