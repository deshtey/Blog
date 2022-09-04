using System.ComponentModel.DataAnnotations;
namespace Blog.Web.Models
{
    public class PostViewModel
    {
        [Required(ErrorMessage = "The post's title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please include a description")]
        public string Description { get; set; }
    }
}
