using Blog.Entities;

namespace Blog.Web.Models
{
    public class RestApiRes
    {
        public string Status { get; set; }
        public int Count { get; set; }
        public List<Post> Articles { get; set; }

    }

    //public class Article
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //    public DateTime PublishedAt { get; set; }
    //}

}
