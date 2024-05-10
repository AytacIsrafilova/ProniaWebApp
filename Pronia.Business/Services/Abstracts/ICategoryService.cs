using ProniaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Services.Abstracts
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void DeleteCategory(int Id);
        void UpdateCategory(int Id,Category newCategory);
        Category GetCategory(Func<Category,bool>? func=null);
        List<Category> GetAllCategory(Func<Category, bool>? func = null);

    }
}
