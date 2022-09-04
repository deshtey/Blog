using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
  
        [Required(ErrorMessage = "The post's title is required")]
        public string Title { get; set; }
     
        [Required(ErrorMessage = "Please include a description")]
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string CreatedBy { get; set; }
        public virtual BlogUser User { get; set; }

    }
}
