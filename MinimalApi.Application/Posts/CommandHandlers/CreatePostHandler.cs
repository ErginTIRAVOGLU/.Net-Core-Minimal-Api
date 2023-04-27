using MediatR;
using MinimalApi.Application.Abstractions;
using MinimalApi.Application.Posts.Commands;
using MinimalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Application.Posts.CommandHandlers
{
    internal class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {
        private readonly IPostRepository _postRepository;

        public CreatePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var newPost = new Post
            {
                Content = request.PostContent
            };

            return await _postRepository.CreatePost(newPost);
        }
    }
}
