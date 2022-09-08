using Blog.Entities;
using Blog.Web;
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
    public class BlogServiceTest
    {
        [Fact]
        public async Task GetPostsReturnsListOfPosts()
        {
            // Arrange
            var blogServiceMock = new Mock<BlogService>();
            var res = blogServiceMock.Setup(b => b.GetPostsAsync());

        }
    }
}
