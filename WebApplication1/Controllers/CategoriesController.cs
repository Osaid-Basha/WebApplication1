using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        ApllicationDbContext context= new ApllicationDbContext();
        public IActionResult Index()
        {
            var categories=context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Details(int id)
        {  
            var category=context.Categories.Find(id);
            return View(category);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View(new Category());
        }
        [HttpPost]
        public IActionResult Create( Category request)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(request);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(request);
            }
        }
        public IActionResult Delete(int id) { 
        
            var category=context.Categories.Find(id);
            if (category is null) { 
            
            return View("NotFund");
            }

            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        
        
        
        }
        [HttpGet]
        public IActionResult Edit(int id) {

            var category = context.Categories.Find(id);
           
            return View(category);
        
        }
        [HttpPut]
        public IActionResult Edit( Category request)
        {
            if (ModelState.IsValid)
            {
               var nameExists= context.Categories.Any(c=>c.Name==request.Name && c.Id !=request.Id );
                if (nameExists)
                {
                    ModelState.AddModelError("Name", "category name is already exists");
                    return View( request);
                } 
                context.Categories.Update(request);
                context.SaveChanges();
                return RedirectToAction("Index");
                
                
            }
            else {
                return View("Edit", request);
                    }
        }

    }
}
