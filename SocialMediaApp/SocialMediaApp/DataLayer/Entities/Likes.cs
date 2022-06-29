namespace SocialMediaApp.DataLayer.Entities
{
    public class Likes : BaseEntity
    {
        public Posts Post { get; set; }
        public User User { get; set; }
    }
}
