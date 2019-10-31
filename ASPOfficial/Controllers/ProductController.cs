using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPOfficial.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPOfficial.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var repo = new ProductRepository();
            var products = repo.GetAllProducts();

            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var repo = new ProductRepository();
            var prod = repo.GetProduct(id);

            if(prod == null)
            {
                return View("ProductNotFound");
            }

            return View(prod);
        }

        public IActionResult OnSale()
        {
            var repo = new ProductRepository();
            var products = repo.GetOnSaleProducts();

            return View(products);
        }

        public IActionResult UpdateProduct(int id)
        {
            var repo = new ProductRepository();
            var product = repo.GetProduct(id);

            repo.UpdateProduct(product);
            if (product == null)
            {
                return View("ProductNotFound");
            }

            return View(product);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            var repo = new ProductRepository();
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product });
        }

        public IActionResult InsertProduct()
        {
            var repo = new ProductRepository();
            var prod = repo.AssignCategories();

            return View(prod); 
        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            var repo = new ProductRepository();
            repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(Product product)
        {
            var repo = new ProductRepository();
            repo.DeleteProductFromAllTables(product.ID);

            return RedirectToAction("Index");
        }
    }
}
