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
        private readonly ICategoryMangement _categoryManagement;
        private readonly ILogger<BlogPostController> _logger;

        public BlogPostController(ILogger<BlogPostController> logger,
            IBlogPostManagement blogPostManagement,
                   ICategoryMangement categoryMangement) 
        {
            _blogPostManagement = blogPostManagement;
            _logger = logger;
            _categoryManagement = categoryMangement;
        }
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult IndexSP()
        {
            var model = new BlogPostListModel();
            model.SetCategoryValues(_categoryManagement.GetCategories());

            return View(model);

        }

        [HttpPost]
        public JsonResult GetBlogPostJsonData([FromBody] BlogPostListModel model)
        {

            var result = _blogPostManagement.GetBlogPosts(model.PageIndex, model.PageSize, model.Search, model.FormatSortExpression("Title", "Id"));
            var blogPostJsonData = new
            {
                recordsTotal = result.total,
                recordsFiltered = result.totaldisplay,
                data = (from record in result.data
                        select new string[]
                        {
                            HttpUtility.HtmlEncode(record.Title),
                            HttpUtility.HtmlEncode(record.Body),
                            HttpUtility.HtmlEncode(record.Category?.Name),
                            record.PostDate.ToString(),
                            record.Id.ToString()
                        }
                    ).ToArray()
            };

            return Json(blogPostJsonData);

        }

        [HttpPost]
        public async Task<JsonResult> GetBlogPostJsonDataSP([FromBody] BlogPostListModel model)
        {

            var result = await _blogPostManagement.GetBlogPostsSP(model.PageIndex, model.PageSize,
                model.SearchItem, model.FormatSortExpression("Title", "Id"));
            var blogPostJsonData = new
            {
                recordsTotal = result.total,
                recordsFiltered = result.totaldisplay,
                data = (from record in result.data
                        select new string[]
                        {
                               HttpUtility.HtmlEncode(record.Title),
                               HttpUtility.HtmlEncode(record.Body),
                               HttpUtility.HtmlEncode(record.CategoryName),
                               record.PostDate.ToString(),
                               record.Id.ToString()
                        }
                    ).ToArray()
            };

            return Json(blogPostJsonData);

        }

        public IActionResult Create()
        {
            var model = new BlogPostCreateModel();
            return View(model);
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
                try
                {
                    
                    _blogPostManagement.CreateBlog(blog);

                    TempData["success"] = "Data inserted successfully";

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Data insert falied,Data should be unique";
                    _logger.LogError(ex, "Blog post creation failed");

                }
               
             

               
              
                return RedirectToAction("Index");   
            }
            return View(model);

        }
        public IActionResult Update(Guid id)
        {
           
            BlogPost Post = _blogPostManagement.GetBlogPosts(id);

            var model = new BlogPostUpdateModel
            {
                Id = Post.Id,
                Title = Post.Title,
            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(BlogPostUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var blog = new BlogPost
                {
                    Id = model.Id,
                    Title = model.Title
                };
                try
                {
                    _blogPostManagement.UpdateBlog(blog);

                    TempData["success"] = "Data updated Successfully";

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Data update falied,Data should be unique";

                    _logger.LogError(ex, "Blog post creation failed");
                    
                   return RedirectToAction("Index");


                }
            }
            return View(model); 
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
             
                try
                {
                    _blogPostManagement.DeleteBlog(id);

                    TempData["success"] = "Data Deleted Successfully";

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Data Delete failed";

                   _logger.LogError(ex, "Blog post creation failed");

                    return RedirectToAction("Index");



                }
            
           
        }





    }
}
