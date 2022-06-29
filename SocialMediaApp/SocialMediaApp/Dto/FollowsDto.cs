namespace SocialMediaApp.Dto
{
    public class FollowsDto
    {
        public UserDto User { get; set; }
        public UserDto FollowedUser { get; set; }
    }
}
