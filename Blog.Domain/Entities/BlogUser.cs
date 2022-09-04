using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities
{
    public class BlogUser : IdentityUser
    {
        public DateTime DateRegistered { get; set; }
        [Required]

        public string Name { get; set; }
    }
}
