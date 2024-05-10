using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApp.DAL;
using ProniaWebApp.Models;

namespace ProniaWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
       

        AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            
            List<Category> categories = _dbContext.Categories.Include(x=>x.Products).ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(!ModelState.IsValid) 
            {
                return View();
            }
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int Id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.Id == Id);
            if(category == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        
        }

        [HttpPost]
        public IActionResult Update(Category newCategory)
        {
            var oldCategory = _dbContext.Categories.FirstOrDefault(x => x.Id == newCategory.Id);
            if (oldCategory == null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            oldCategory.Name= newCategory.Name;
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete(int? id)
        {
            var category=_dbContext.Categories.FirstOrDefault(x=>x.Id==id);
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
