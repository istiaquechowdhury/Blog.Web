using Blog.Application.Services;
using Blog.Domain.Entities;
using Blog.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BlogPostController : Controller
    {
        private readonly IBlogPostManagement _blogPostManagement;

        public BlogPostController(IBlogPostManagement blogPostManagement) 
        {
            _blogPostManagement = blogPostManagement;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(BlogPostCreateModel model)
        {
            if(ModelState.IsValid)
            {
                var blog = new BlogPost
                {
                    Id = Guid.NewGuid(),    
                    Title = model.Title
                };

                _blogPostManagement.CreateBlog(blog);
                return RedirectToAction("Index");   
            }
            return View(model);

        }


    }
}
