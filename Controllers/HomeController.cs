using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blog.Models;

namespace blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult account()
        {
            ViewData["Message"] = "Your account page.";

            return View();
        }

        public IActionResult checkout()
        {
            ViewData["Message"] = "Your checkout page.";

            return View();
        }

        public IActionResult Products()
        {
            ViewData["Message"] = "Your products page.";

            return View();
        }
        public IActionResult Register()
        {
            ViewData["Message"] = "Your register page.";

            return View();
        }

        public IActionResult Single()
        {
            ViewData["Message"] = "Your single page.";

            return View();
        }

        public IActionResult productt()
        {
            ViewData["Message"] = "Your products page.";

            return View();
        }
        public IActionResult Nothing()
        {
            ViewData["Message"] = "Your products page.";

            return View();
        }

        public IActionResult MenShirt()
        {
            ViewData["Message"] = "Your products page.";

            return View();
        }
        public IActionResult MenOoji()
        {
            ViewData["Message"] = "Your products page.";

            return View();
        }

        public IActionResult Dress()
        {
            ViewData["Message"] = "Your products page.";

            return View();
        }
        public IActionResult DressOoji()
        {
            ViewData["Message"] = "Your products page.";

            return View();
        }
        public IActionResult dressLove()
        {
            ViewData["Message"] = "Your products page.";

            return View();
        }


         public IActionResult admin()
        {
            ViewBag.products = ListProducts;
			return View();
        }

    //     [HttpGet]
	// 	public IActionResult Create()
	// 	{
	// 		// var product = new ProductClass();
	// 		// return View(product);
    //         return View();
	// 	}

	// 	[HttpPost]
    //     [ValidateAntiForgeryToken]
	// 	public IActionResult Create( ProductClass product)
	// 	{ 
    //         //   if (string.IsNullOrEmpty(product.name))
    //         //     {
    //         //         ModelState.AddModelError("name", "Некорректное имя");
    //         //     }
                
    //         //  if (string.IsNullOrEmpty(ProductClass.name))
    //         // {
    //         //     ModelState.AddModelError("Name", "Некорректное название книги");
    //         // }
    //         // else if (ProductClass.name.Length > 20)
    //         // {
    //         //     ModelState.AddModelError("name", "Недопустимая длина строки");
    //         // }
    //         // int id = product.id;
    //         // string str = product.name;
    //         // int money = product.money;
    //         if (ModelState.IsValid){
    //             ViewBag.Message = "Valid";
    //             ListProducts.Add(product);
    //             return Redirect("/Home/admin");
	// 		}
    //          ViewBag.Message = "Non Valid";
	// 		return View();
	// 	}


    //     [HttpGet]
	// 	public IActionResult Edit(int ID = -1)
	// 	{
	// 		var producttt = ListProducts.SingleOrDefault(p => p.id == ID);

	// 		// if ( producttt == null )
	// 		// {
	// 		// 	return HttpNotFound();
	// 		// }

	// 		return View(producttt);
	// 	}


    //     [HttpPost]
	// 	public IActionResult Edit(int ID, ProductClass product)
	// 	{
	// 		var dbProduct = ListProducts.SingleOrDefault( p => p.id == ID );

	// 		dbProduct.id = product.id;
	// 		dbProduct.name = product.name;
	// 		dbProduct.money = product.money;
			

	// 		return Redirect( "/Home/admin" );
	// 	}

    //     [HttpGet]
    // public ActionResult Delete()
    // {

         
    //     return View();

    // }

    // [HttpPost]
    // public ActionResult Delete(ProductClass product)
    // {   

    //      ListProducts.Remove(product);
    //      return Redirect( "/Home/admin" );


    // }

// [HttpPost]
//         public IActionResult Delete(int ID)
//             {
//                 //ProductClass product = ListProducts.get
//                ProductClass product = ListProducts.Find(c=>c.id==ID);
//                 ListProducts.Remove(product);

//                 return Redirect( "/Home/admin" );
//             }

               public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

         public ProductClass GetProductById(int ID)
   {
       
       var prod = (from p in ListProducts
                   where p.id==ID
                   select p).Single();
         return prod;

   }

         public static List<ProductClass> ListProducts = new List<ProductClass>{
              new ProductClass (1, "Юбка", 3000),
                new ProductClass (2, "Платье", 4500),
                new ProductClass (1, "Пиджак", 7000),
                new ProductClass (3, "Брюки синие", 3000),
                new ProductClass (4, "Шорты", 4500),
                new ProductClass (5, "Свитер", 7000)};

    }
}
