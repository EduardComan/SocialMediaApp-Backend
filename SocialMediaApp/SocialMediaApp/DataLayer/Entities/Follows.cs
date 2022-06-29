namespace SocialMediaApp.DataLayer.Entities
{
    public class Follows : BaseEntity
    {
        public User User { get; set; }
        public User FollowedUser { get; set; }
    }
}
