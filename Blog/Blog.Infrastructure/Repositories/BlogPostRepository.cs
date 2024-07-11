using Blog.Domain;
using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories
{
    public class BlogPostRepository : Repository<BlogPost, Guid>,IBlogPostRepository
    {
        public BlogPostRepository(BlogDbContext context) : base(context)
        {
        }

        public (IList<BlogPost>,int total,int totaldisplay) GetPagedBlogPosts(int pageIndex, int pageSize, DataTablesSearch search, string? order)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            else
                return GetDynamic(x => x.Title == search.Value, order, null, pageIndex, pageSize, true);
        }
    }
}
