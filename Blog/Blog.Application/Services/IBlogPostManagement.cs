﻿using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public interface IBlogPostManagement
    {
        public void CreateBlog(BlogPost blogPost);
    }
}
