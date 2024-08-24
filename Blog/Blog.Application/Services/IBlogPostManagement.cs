using Blog.Domain;
using Blog.Domain.Dtos;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Blog.Application.Services
{
    public interface IBlogPostManagement
    {
        void CreateBlog(BlogPost blogPost);
        void DeleteBlog(Guid id);
        (IList<BlogPost> data,int total,int totaldisplay) GetBlogPosts(int pageIndex, int pageSize, DataTablesSearch search, string? order);
        Task<(IList<BlogPostDto> data, int total, int totaldisplay)> GetBlogPostsSP(int pageIndex, int pageSize, BlogPostSearchDto search, string? order);

        Task <BlogPost> GetBlogPost(Guid id);
        void UpdateBlog(BlogPost blog);
    }
}
