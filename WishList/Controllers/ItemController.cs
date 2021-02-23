using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _context.Items;
            
            return View("Index",items.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
         

            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {

       
                
                    _context.Items.Add(item);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                
           

           
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {

           
                _context.Items.Remove(_context.Items.Find(Id));
                _context.SaveChanges();
                return RedirectToAction("Index");
            
           
        }
    }
}
