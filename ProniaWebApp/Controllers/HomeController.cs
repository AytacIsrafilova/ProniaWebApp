using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApp.DAL;
using ProniaWebApp.Models;
using ProniaWebApp.ViewModel;
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



        public IActionResult Index()
        {
            List<Product>products= _dbContext.Products.Include(x=>x.ProductPhotos).Where(x=>x.ProductPhotos.Count>0).ToList();
            HomeVM homeVM = new HomeVM()
            {
                Products = products,
                Sliders=_dbContext.Sliders.ToList(),
            };


            return View(products);
        }

        public IActionResult Detail(int?id)
        {
            return View();
        }
        
    }
}
