using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBuggetoEx.DTO;
using RazorBuggetoEx.Services;

namespace RazorBuggetoEx.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        public List<ProductDto> products { get; set; } = new List<ProductDto>();
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            products = _productService.List();
        }
    }
}

