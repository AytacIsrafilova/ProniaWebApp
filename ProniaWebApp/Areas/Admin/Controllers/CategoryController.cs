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

        public IActionResult Details(int? id)
        {
            var category=_dbContext.Categories.FirstOrDefault(x=>x.Id==id);
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
