using MediatR;
using MinimalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Application.Posts.Queries
{
    public class GetAllPosts : IRequest<ICollection<Post>>
    {

    }
}
