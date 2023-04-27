﻿using Microsoft.EntityFrameworkCore;
using MinimalApi.Application.Abstractions;
using MinimalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialDbcontext _ctx;

        public PostRepository(SocialDbcontext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Post> CreatePost(Post toCreate)
        {
            toCreate.DateCreated = DateTime.Now;
            toCreate.LastModified = DateTime.Now;
            _ctx.Posts.Add(toCreate);
            await _ctx.SaveChangesAsync();  
            return toCreate;
        }

        public async Task DeletePost(int postId)
        {
            var post = await _ctx.Posts
                .FirstOrDefaultAsync(p=> p.Id == postId);
            
            if(post == null) 
            { 
                return; 
            }
            
            _ctx.Posts.Remove(post);
            await _ctx.SaveChangesAsync();
        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            return await _ctx.Posts.ToListAsync();
        }

        public async Task<Post> GetPostById(int postId)
        {
            return await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<Post> UpdatePost(string updatedContent, int postId)
        {
            var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            post.LastModified= DateTime.Now;    
            post.Content = updatedContent;
            await _ctx.SaveChangesAsync();
            return post;
        }
    }
}
