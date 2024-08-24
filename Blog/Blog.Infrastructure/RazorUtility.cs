using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Infrastructure
{
    public class RazorUtility
    {
        public static IList<SelectListItem> SetCategoryValues(IList<Category> categories)
        {
           var Categories = (from c in categories
                          select new SelectListItem(c.Name, c.Id.ToString()))
                        .ToList();

            Categories.Insert(0, new SelectListItem("Select a Category", string.Empty));

            return Categories;  
        }
    }
}
