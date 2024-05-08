using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApp.DAL;
using ProniaWebApp.Models;
using System.Diagnostics;

namespace ProniaWebApp.Controllers
{
    public class HomeController : Controller
    {

        AppDbContext _dbContext;
        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<IActionResult> Index()
        {
            List<Product>products=await _dbContext.Products.Include(x=>x.ProductPhotos).Where(x=>x.ProductPhotos.Count>0).ToListAsync();


            return View(products);
        }

        public IActionResult Detail(int?id)
        {
            return View();
        }
        
    }
}
