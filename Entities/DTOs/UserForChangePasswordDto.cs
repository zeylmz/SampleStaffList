﻿namespace Entities.DTOs
{
    public class UserForChangePasswordDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
