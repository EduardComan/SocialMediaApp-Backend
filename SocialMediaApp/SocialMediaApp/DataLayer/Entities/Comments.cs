using System.ComponentModel.DataAnnotations;

namespace SocialMediaApp.DataLayer.Entities
{
    public class Comments: BaseEntity
    {
        public Posts Post { get; set; }

        public User User { get; set; }

        [Required(ErrorMessage = "Text required!")]
        public string Text { get; set; }

        public DateTime Posted_Date { get; set; }
    }
}
