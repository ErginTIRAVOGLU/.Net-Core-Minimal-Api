using MediatR;
using MinimalApi.Application.Abstractions;
using MinimalApi.Application.Posts.Commands;
using MinimalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Application.Posts.CommandHandlers
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
    {
        private readonly IPostRepository _postRepository;

        public UpdatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.UpdatePost(request.PostContent, request.PostId);
            return post;
        }
    }
}
