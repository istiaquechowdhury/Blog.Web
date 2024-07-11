using Blog.Domain;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class BlogPostManagement : IBlogPostManagement
    {
        private readonly IBlogUnitOfWork _blogunitOfWork;
        public BlogPostManagement(IBlogUnitOfWork blogUnitOfWork) 
        {
            _blogunitOfWork = blogUnitOfWork;

        }
        public void CreateBlog(BlogPost blogPost)
        {
            _blogunitOfWork.BlogPostRepository.Add(blogPost);
            _blogunitOfWork.Save();    
        }

        public (IList<BlogPost> data, int total, int totaldisplay) GetBlogPosts(int pageIndex, int pageSize, DataTablesSearch search, string? order)
        {
           return _blogunitOfWork.BlogPostRepository.GetPagedBlogPosts(pageIndex, pageSize, search, order);
        }
    }
}
