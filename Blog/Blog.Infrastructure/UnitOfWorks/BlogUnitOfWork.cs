using Blog.Application;
using Blog.Domain;
using Blog.Domain.Dtos;
using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blog.Infrastructure.UnitOfWorks
{
    public class BlogUnitOfWork : UnitOfWork,IBlogUnitOfWork
    {
        public IBlogPostRepository BlogPostRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public BlogUnitOfWork(BlogDbContext dbContext,
             IBlogPostRepository _BlogPostRepository,
             ICategoryRepository categoryRepository) : base(dbContext)
        {
            BlogPostRepository = _BlogPostRepository;
            CategoryRepository = categoryRepository;
        }

        public async Task<(IList<BlogPostDto> data, int Total, int TotalDisplay)> GetPagedBlogPostsUsingSPAsync(int pageIndex, int pageSize,
            BlogPostSearchDto search, string? order)
        {
            var procedureName = "GetBlogPosts";

            var result = await SqlUtility.QueryWithStoredProcedureAsync<BlogPostDto>(procedureName,
                new Dictionary<string, object>
                {
                    { "PageIndex", pageIndex },
                    { "PageSize", pageSize },
                    { "OrderBy", order },
                    { "Title", search.Title == string.Empty? null : search.Title},
                    {"CategoryId",search.CategoryId == Guid.Empty ? null : search.CategoryId},
                },
                new Dictionary<string, Type>
                {
                    { "Total", typeof(int) },
                    { "TotalDisplay", typeof(int) },
                });

            return (result.result, (int)result.outValues["Total"], (int)result.outValues["TotalDisplay"]);
        }
    }
}
