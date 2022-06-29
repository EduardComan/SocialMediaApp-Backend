using System.ComponentModel.DataAnnotations;

namespace SocialMediaApp.DataLayer.Entities
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Username required!")]
        [MaxLength(15, ErrorMessage = "Username too long!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email required!")]
        [MinLength(5, ErrorMessage = "Email must be at least 5 characters long!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required!")]
        [MinLength(4, ErrorMessage = "Password must be at least 4 characters long!")]
        public string Password { get; set; }

        public string ProfilePicLink { get; set; }

        public enum Role
        {
            Admin,
            User
        }

        public int IsDeletd { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<Likes> Likes { get; set; }
        public ICollection<Reports> Reports { get; set; }
        public ICollection<Follows> Follows { get; set; }
    }
}
