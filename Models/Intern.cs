﻿namespace InternAPI.Models
{
    public class Intern
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Education { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Gender { get; set; } = "";
        public string Duration { get; set; } = "";
    }
}
