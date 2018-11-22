using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using blog.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace blog.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MVCProductsContext _context;
  //private readonly IHostingEnvironment he;

        public ProductsController(MVCProductsContext context)
        {
            _context = context;
          
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Product.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productClass = await _context.Product
                .SingleOrDefaultAsync(m => m.id == id);
            if (productClass == null)
            {
                return NotFound();
            }

            return View(productClass);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,photo,name,money,description")] ProductClass productClass, List<IFormFile> photo )
        {
            
            if (ModelState.IsValid)
            {
                

                foreach(var item in photo){
                    if(item.Length>0){
                        using(var stream = new MemoryStream()) {
                                await item.CopyToAsync(stream);
                                productClass.photo = stream.ToArray();
                                //return new FileStreamResult(new System.IO.MemoryStream(productClass.photo), "image/jpeg");
                        }
                    }
                }
                // if (pic!=null){
                //     var fileName = Path.Combine(he.WebRootPath, Path.GetFileName(pic.FileName));
                //     pic.CopyTo(new FileStream(fileName, FileMode.Create));
                //     ViewData["fileLocation"] = "/" + Path.GetFileName(pic.FileName);
                //                   }
    //             var productt = new ProductClass{
    //                 name = productClass.name,
    //                 money = productClass.money,
    //                 description = productClass.description
    //             };
    //             //Person person = new Person { Name = pvm.Name };
    // if (productClass.photo != null)
    // {
    //     byte[] imageData = null;
    //     // считываем переданный файл в массив байтов
    //     using (var binaryReader = new BinaryReader(productClass.photo.OpenReadStream()))
    //     {
    //         imageData = binaryReader.ReadBytes((int)productClass.photo.Length);
    //     }
    //     // установка массива байтов
    //     productt.photo = imageData;
    // }
                _context.Add(productClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productClass);
        }
        public IActionResult Image(int productId)
        {
            var pr=    _context.Product.Find(productId);
            System.Console.WriteLine(productId);
            System.Console.WriteLine(pr);
            
            MemoryStream ms = new MemoryStream(pr.photo);
            return new FileStreamResult(ms,"image/png");
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productClass = await _context.Product.SingleOrDefaultAsync(m => m.id == id);
            if (productClass == null)
            {
                return NotFound();
            }
            return View(productClass);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,photo,name,money,description")] ProductClass productClass)
        {
            if (id != productClass.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductClassExists(productClass.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productClass);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productClass = await _context.Product
                .SingleOrDefaultAsync(m => m.id == id);
            if (productClass == null)
            {
                return NotFound();
            }

            return View(productClass);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productClass = await _context.Product.SingleOrDefaultAsync(m => m.id == id);
            _context.Product.Remove(productClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductClassExists(int id)
        {
            return _context.Product.Any(e => e.id == id);
        }
    }
}
