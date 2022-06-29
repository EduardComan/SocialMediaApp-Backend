﻿using System.ComponentModel.DataAnnotations;

namespace SocialMediaApp.DataLayer.Entities
{
    public class Posts : BaseEntity
    {
        public User User { get; set; }

        [Required(ErrorMessage = "Text required!")]
        public string Text { get; set; }

        public DateTime Posted_Date { get; set; }

    }
}