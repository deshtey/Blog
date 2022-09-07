using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities
{
    public class BlogUser : IdentityUser
    {
        public DateTime DateRegistered { get; set; }
        [Required]

        public string Name { get; set; }
        public virtual ICollection<Post>? BlogEntries { get; set; }
    }
}
