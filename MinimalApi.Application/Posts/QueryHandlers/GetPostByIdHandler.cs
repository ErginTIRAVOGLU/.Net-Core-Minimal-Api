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
    public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
    {
        private readonly IPostRepository _postRepository;

        public GetPostByIdHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetPostById(request.PostId);
        }
    }
}
