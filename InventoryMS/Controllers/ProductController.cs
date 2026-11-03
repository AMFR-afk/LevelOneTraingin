using Microsoft.AspNetCore.Mvc;

namespace InventoryMS.Controllers
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
            return View(product);
        }

        //-------------------EditProduct----------------------
        public async Task<IActionResult> EditProduct(int Id)
        {
            var avalable = await _bridge.Products.FindAsync(Id);
            if (avalable == null)
            {
                return NotFound();
            }

            return View(avalable);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            var avalable = await _bridge.Products.FindAsync(product.Id);
            if (avalable == null)
            {
                return RedirectToAction("PrintAll");
            }
            if (ModelState.IsValid)
            {
                avalable.Name = product.Name;
                avalable.Price = product.Price;
                avalable.Quantity = product.Quantity;
                avalable.Category = product.Category;
                avalable.Description = product.Description;
                await _bridge.SaveChangesAsync();
                return RedirectToAction("PrintAll");
            }

            return View(product);
        }

        //-------------------DeleteProduct----------------------

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var avalable = await _bridge.Products.FindAsync(Id);

            if (avalable == null)
            {
                return NotFound();
            }

            return View(avalable);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public async Task<IActionResult> Delete(int Id)
        {
            var avalable = await _bridge.Products.FindAsync(Id);
            if (avalable == null)
            {
                return RedirectToAction("PrintAll");
            }

            _bridge.Products.Remove(avalable);
            await _bridge.SaveChangesAsync();
            return RedirectToAction("PrintAll");
        }



    }
}
