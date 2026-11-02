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

        //-------------------PrintAll----------------------
        public ActionResult PrintAll()
        {
            var productList = _bridge.Products.ToList();
            return View(productList);
        }

        //-------------------AddProduct----------------------

        public ActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await _bridge.AddAsync(product);
                await _bridge.SaveChangesAsync();
                return RedirectToAction("PrintAll");

            }
            return View();
        }

        //-------------------EditProduct----------------------

        public ActionResult EditProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(int Id)
        {
            var avalable = await _bridge.Products.FindAsync(x => x.Id == Id);
            return View();
        }

        //-------------------DeleteProduct----------------------


        public ActionResult DeleteProduct()
        {
            return View();
        }

    }
}
