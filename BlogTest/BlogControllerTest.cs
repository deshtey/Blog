using Blog.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest
{
    public class BlogControllerTest
    {
        [Fact]
        public async Task IndexReturnsAView()
        {
            // Arrange
            var controller = new HomeController(repository: null);

            // Act
            var result = await controller.Index();

            // Assert
            var redirectToActionResult =
                Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
