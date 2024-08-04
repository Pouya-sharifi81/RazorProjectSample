using Microsoft.AspNetCore.Mvc;
using Moq;
using RazorBuggetoEx.DTO;
using RazorBuggetoEx.Pages.Admin.Products;
using RazorBuggetoEx.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorBuggetoTest
{
    public class ProductPageTests
    {
        private readonly Mock<IProductService> _mockProductService;

        public ProductPageTests()
        {
            _mockProductService = new Mock<IProductService>();
        }


        [Fact]
        public void CreateModel_OnPost_AddsProduct()
        {
            // Arrange
            var productDto = new ProductDto { Id = 1, Name = "Test Product" };
            _mockProductService.Setup(s => s.Add(It.IsAny<ProductDto>())).Verifiable();
            var pageModel = new CreateModel(_mockProductService.Object)
            {
                product = productDto
            };

            // Act
            pageModel.OnPost();

            // Assert
            _mockProductService.Verify(s => s.Add(productDto), Times.Once);
        }

        [Fact]
        public void DeleteModel_OnGet_ReturnsNotFound_WhenIdIsNull()
        {
            // Arrange
            var pageModel = new DeleteModel(_mockProductService.Object);

            // Act
            var result = pageModel.OnGet(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteModel_OnPost_DeletesProductAndRedirects()
        {
            // Arrange
            var productDto = new ProductDto { Id = 1, Name = "Test Product" };
            _mockProductService.Setup(s => s.Delete(It.IsAny<int>())).Verifiable();
            var pageModel = new DeleteModel(_mockProductService.Object)
            {
                Product = productDto
            };

            // Act
            var result = pageModel.OnPost();

            // Assert
            _mockProductService.Verify(s => s.Delete(productDto.Id), Times.Once);
            var redirectToPageResult = Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal("Index", redirectToPageResult.PageName);
        }

        [Fact]
        public void EditModel_OnGet_ReturnsNotFound_WhenIdIsNull()
        {
            // Arrange
            var pageModel = new EditModel(_mockProductService.Object);

            // Act
            var result = pageModel.OnGet(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void IndexModel_OnGet_PopulatesProducts()
        {
            // Arrange
            var productList = new List<ProductDto>
        {
            new ProductDto { Id = 1, Name = "Test Product" }
        };
            _mockProductService.Setup(s => s.List()).Returns(productList);
            var pageModel = new IndexModel(_mockProductService.Object);

            // Act
            pageModel.OnGet();

            // Assert
            Assert.NotNull(pageModel.products);
            Assert.Single(pageModel.products);
        }
    }
}
