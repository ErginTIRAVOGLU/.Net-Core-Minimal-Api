using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.DataAccess
{
    public class SocialDbcontext:DbContext
    {
        public SocialDbcontext(DbContextOptions opt) : base(opt)
        {
            
        }

        public DbSet<Post> Posts { get; set; }

    }
}
