using GeekShopping.Web.Models;
using GeekShopping.Web.Models.Product;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiService _productService;
        

        public ProductController(IProductApiService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));            
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.FindAll();

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");

                var response = await _productService.Create(model, token);

                if (response != null) return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var model = await _productService.FindById(id, token);

            if (model != null) 
                return View(model);
            
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");

                var response = await _productService.Update(model, token);

                if (response != null) 
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var model = await _productService.FindById(id, token);

            if (model != null) 
                return View(model);
            
            return NotFound();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> Delete(ProductViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var response = await _productService.Delete(model.Id, token);

            if (response) 
                return RedirectToAction(nameof(Index));

            return View(model);
        }
    }
}