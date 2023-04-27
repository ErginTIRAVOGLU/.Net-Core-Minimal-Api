using MediatR;
using MinimalApi.Application.Abstractions;
using MinimalApi.Application.Posts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Application.Posts.CommandHandlers
{
    public class DeletePostHandler : IRequestHandler<DeletePost>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task Handle(DeletePost request, CancellationToken cancellationToken)
        {
            await _postRepository.DeletePost(request.PostId);
             
        }
        /*
        public async Task<Unit> Handle(DeletePost request, CancellationToken cancellationToken)
        {
           await _postRepository.DeletePost(request.PostId);
           return Unit.Value;
        }

        Task IRequestHandler<DeletePost>.Handle(DeletePost request, CancellationToken cancellationToken)
        {
           throw new NotImplementedException();
        }
        */
    }
}
