using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Allup.Models;
using Allup.DAL;
using Allup.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Allup.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Categorys = _context.Categories.Where(c => c.IsMain == true && c.IsDeleted == false).ToList(),
                Products= _context.Products.Include(p=>p.Images).Where(c => c.IsDeleted == false).ToList()
            };
            return View(homeVM);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
