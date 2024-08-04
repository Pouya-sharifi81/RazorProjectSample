using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBuggetoEx.DTO;
using RazorBuggetoEx.Services;

namespace RazorBuggetoEx.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _productService;
        [BindProperty]
        public ProductDto Product { get; set; }
        public DeleteModel(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product = _productService.Find(id.Value);
            return Page();
        }
        public IActionResult OnPost()
        {
            _productService.Delete(Product.Id);
            return RedirectToPage("Index");
        }
    }
}
