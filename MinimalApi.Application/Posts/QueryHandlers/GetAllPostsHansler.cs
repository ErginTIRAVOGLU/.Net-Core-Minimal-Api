using MediatR;
using MinimalApi.Application.Abstractions;
using MinimalApi.Application.Posts.Queries;
using MinimalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Application.Posts.QueryHandlers
{
    public class GetAllPostsHansler : IRequestHandler<GetAllPosts, ICollection<Post>>
    {
        private readonly IPostRepository _postRepository;

        public GetAllPostsHansler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetAllPosts();
        }
    }
}
