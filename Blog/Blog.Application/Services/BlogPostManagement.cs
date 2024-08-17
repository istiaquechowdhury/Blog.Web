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
    public class BlogPostManagement : IBlogPostManagement
    {
        private readonly IBlogUnitOfWork _blogunitOfWork;
        public BlogPostManagement(IBlogUnitOfWork blogUnitOfWork) 
        {
            _blogunitOfWork = blogUnitOfWork;

        }
        public void CreateBlog(BlogPost blogPost)
        {
            if (!_blogunitOfWork.BlogPostRepository.IsTitleDuplicate(blogPost.Title))
            {
                _blogunitOfWork.BlogPostRepository.Add(blogPost);
                _blogunitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Title should be unique.");

        }

        public void DeleteBlog(Guid id)
        {
             _blogunitOfWork.BlogPostRepository.Remove(id);
            _blogunitOfWork.Save();
        }

        public (IList<BlogPost> data, int total, int totaldisplay) GetBlogPosts(int pageIndex, int pageSize, DataTablesSearch search, string? order)
        {
           return _blogunitOfWork.BlogPostRepository.GetPagedBlogPosts(pageIndex, pageSize, search, order);
        }

        public BlogPost GetBlogPosts(Guid id)
        {
            return _blogunitOfWork.BlogPostRepository.GetById(id);
        }

        public async Task<(IList<BlogPostDto> data, int total, int totaldisplay)> GetBlogPostsSP(int pageIndex, int pageSize, BlogPostSearchDto search, string? order)
        {
            return await _blogunitOfWork.GetPagedBlogPostsUsingSPAsync(pageIndex, pageSize, search, order);
        }

        public void UpdateBlog(BlogPost blogPost)
        {
            if (!_blogunitOfWork.BlogPostRepository.IsTitleDuplicate(blogPost.Title, blogPost.Id))
            {
                _blogunitOfWork.BlogPostRepository.Edit(blogPost);
                _blogunitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Title should be unique.");
        }
    }
}
