﻿using System.ComponentModel.DataAnnotations;

namespace SocialMediaApp.Dto
{
    public class UserDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}