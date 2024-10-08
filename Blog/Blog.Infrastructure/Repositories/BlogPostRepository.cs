﻿using Blog.Domain;
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
    public class BlogPostRepository : Repository<BlogPost, Guid>, IBlogPostRepository
    {
        public BlogPostRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<BlogPost> GetBlogPost(Guid id)
        {
            return (await GetAsync(x => x.Id == id, y => y.Include(z => z.Category))).FirstOrDefault();
        }

        public (IList<BlogPost>, int total, int totaldisplay) GetPagedBlogPosts(int pageIndex, int pageSize, DataTablesSearch search, string? order)
        {
            DateTime searchDate;
            bool isDateSearch = DateTime.TryParse(search.Value, out searchDate);

            if (string.IsNullOrWhiteSpace(search.Value))
                return GetDynamic(null, order, y => y.Include(z => z.Category), pageIndex, pageSize, true);
            else
            

            return GetDynamic(
                x => x.Title.Contains(search.Value) ||
                     x.Body.Contains(search.Value) ||
                     x.Category.Name.Contains(search.Value) ||
                     (isDateSearch && x.PostDate.Date == searchDate.Date), // Compare only the date part
                order,
                y => y.Include(z => z.Category),
                pageIndex,
                pageSize,
                true
            );
        }

        public bool IsTitleDuplicate(string title, Guid? id = null)
        {
            if (id.HasValue)
            {
                return GetCount(x => x.Id != id.Value && x.Title == title) > 0;
            }
            else
            {
                return GetCount(x => x.Title == title) > 0;
            }
        }
    }
}
