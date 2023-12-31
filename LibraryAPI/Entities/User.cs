﻿namespace LibraryAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string PasswordHash { get; set; }
    }
}
