using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBuggetoEx.DTO;
using RazorBuggetoEx.Services;

namespace RazorBuggetoEx.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public ProductDto product { get; set; }
        private readonly IProductService _productService;

        public CreateModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
        }
        public void OnPost() 
        {
            _productService.Add(product);
        }
    }
}
