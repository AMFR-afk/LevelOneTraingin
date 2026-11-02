using InventoryMS;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class ProductController : Controller
    {
        // GET: ProductController
        private readonly Bridge _bridge; 
        public ProductController(Bridge b)
        {
            _bridge = b;
        }
        public ActionResult PrintAll()
        {
            var productList = _bridge.Products.ToList();
            return View(productList);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult EditProduct()
        {
            return View();
        }

        public ActionResult DeleteProduct()
        {
            return View();
        }

    }
}
