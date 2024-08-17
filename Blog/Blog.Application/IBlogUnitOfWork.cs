using Blog.Domain;
using Blog.Domain.Dtos;
using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application
{
    public interface IBlogUnitOfWork : IUnitOfWork
    {
        public IBlogPostRepository BlogPostRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public Task<(IList<BlogPostDto> data, int Total, int TotalDisplay)> GetPagedBlogPostsUsingSPAsync(int pageIndex,
            int pageSize, BlogPostSearchDto search, string? order);
    }
}
