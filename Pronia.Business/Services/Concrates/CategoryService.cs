using Pronia.Business.Exceptions;
using Pronia.Business.Services.Abstracts;
using Pronia.Core.RepositoryAbstracts;
using ProniaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Concrates
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void AddCategory(Category category)
        {
            if (category == null) throw new NullReferenceException("Category null ola bilmez!");
            if (!_categoryRepository.GetAll().Any(x => x.Name == category.Name))
            {
                _categoryRepository.Add(category);
                _categoryRepository.Commit();
            }
            else
            {
                throw new DuplicateCategoryException("Category adi eyni ola bilmez!");
            }
        }

        public void DeleteCategory(int Id)
        {
           var existCategory =_categoryRepository.Get(x=>x.Id == Id);
            if (existCategory==null)
            {
                throw new NullReferenceException("Category yoxdur!");
            }
            _categoryRepository.Delete(existCategory);
            _categoryRepository.Commit();
        }

        public List<Category> GetAllCategory(Func<Category, bool>? func = null)
        {
            return _categoryRepository.GetAll();
        }

        public Category GetCategory(Func<Category, bool>? func = null)
        {
            return _categoryRepository.Get();
        }

        public void UpdateCategory(int Id, Category newCategory)
        {
            var existCategory = _categoryRepository.Get(x => x.Id == Id);
            if (existCategory == null) throw new NullReferenceException("Category yoxdur!");

            if (!_categoryRepository.GetAll().Any(x => x.Name == newCategory.Name))
            {
                existCategory.Name= newCategory.Name;
                _categoryRepository.Commit();
            }
            else
            {
                throw new DuplicateCategoryException("Category adi eyni ola bilmez!");

            }

        }
    }
}
