using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Contracts;
using ShoppingListApp.Models.Product;

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

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            await productService.AddProductAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id) 
        {
            var model = await productService.GetByIdReadonlyAsync(Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            await productService.UpdateProductAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductViewModel model)
        {
            await productService.DeleteProductAsync(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
