using Blog.Domain.Dtos;
using Blog.Domain.Entities; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.RepositoryContracts
{
    public interface IBlogPostRepository : IRepositoryBase<BlogPost, Guid>
    {
        (IList<BlogPost>, int total, int totaldisplay) GetPagedBlogPosts(int pageIndex, int pageSize, DataTablesSearch search, string? order);


        public bool IsTitleDuplicate(string title,Guid? id = null);

        Task <BlogPost> GetBlogPost(Guid id);  
    }
}
