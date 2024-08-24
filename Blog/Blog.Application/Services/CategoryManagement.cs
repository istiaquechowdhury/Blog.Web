using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class CategoryManagement : ICategoryMangement
    {
        private readonly IBlogUnitOfWork _blogunitOfWork;
        public CategoryManagement(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogunitOfWork = blogUnitOfWork;

        }
        public IList<Category> GetCategories()
        {
            return _blogunitOfWork.CategoryRepository.GetAll();
        }

        public Category GetCategory(Guid Id)
        {
            return _blogunitOfWork.CategoryRepository.GetById(Id);
        }
    }
}
