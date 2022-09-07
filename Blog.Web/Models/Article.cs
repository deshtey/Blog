using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Web.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string AuthorId { get; set; }
    }
}
