using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Entities
{
    public class Post
    {
        public int Id { get; set; }
  
        [Required(ErrorMessage = "The post's title is required")]
        public string Title { get; set; }
     
        [Required(ErrorMessage = "Please include a description")]
        public string Description { get; set; }
        public DateTimeOffset PublishedAt { get; set; }

        [ForeignKey("Id")]
        public string AuthorId { get; set; }
   
        public virtual BlogUser Author { get; set; }

    }
}
