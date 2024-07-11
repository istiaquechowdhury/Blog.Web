using Blog.Application;
using Blog.Application.Services;
using Blog.Domain.Entities;
using Blog.Infrastructure.Repositories;
using Blog.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

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

        public JsonResult GetBlogPostJsonData( BlogPostListModel model)
        {

            var result = _blogPostManagement.GetBlogPosts(model.PageIndex, model.PageSize, model.Search, model.FormatSortExpression("Title"));
            var blogPostJsonData = new
            {
                recordsTotal = result.total,
                recordsFiltered = result.totaldisplay,
                data = (from record in result.data
                        select new string[]
                        {
                                HttpUtility.HtmlEncode(record.Title),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };

            return Json(blogPostJsonData);

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
                TempData["success"] = "Data Inserted Successfully";
                return RedirectToAction("Index");   
            }
            return View(model);

        }


    }
}
