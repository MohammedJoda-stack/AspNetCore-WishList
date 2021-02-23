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

           
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Items.Add(item);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException er /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {

            var foundItem =  _context.Items.Find(Id);
            if (foundItem == null)
            {
                
                return RedirectToAction("Index");
            }
            try
            {
                _context.Remove(foundItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException er /* ex */)
            {
                return RedirectToAction("Index");
            }

           
        }
    }
}
