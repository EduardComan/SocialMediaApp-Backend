using System;
using System.Collections.Generic;

#nullable disable

namespace SocialMediaApp.DataDB
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime PostedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
