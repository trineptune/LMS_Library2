﻿namespace UserWebApi.Models
{
    public class LoginDTO
    {
        public string Email { get; set; }    
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
