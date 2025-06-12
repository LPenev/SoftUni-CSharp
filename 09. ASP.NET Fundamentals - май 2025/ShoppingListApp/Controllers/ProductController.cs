using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Contracts;

namespace ShoppingListApp.Controllers
{
    public class 
        ProductController(IProductService productService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = await productService.GetAllAsync();
            return View(model);
        }
    }
}
