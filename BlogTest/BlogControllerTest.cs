using Blog.Data;
using Blog.Entities;
using Blog.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
            var mockRepo = new Mock<IBlogService>();
            mockRepo.Setup(repo => repo.GetPostsAsync())
                .ReturnsAsync(new List<Post>());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

  
    }
}
