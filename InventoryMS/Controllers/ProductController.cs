using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult PrintAll()
        {
            return View();
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
