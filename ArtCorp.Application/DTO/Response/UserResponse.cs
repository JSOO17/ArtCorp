﻿namespace ArtCorp.Application.DTO.Response
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Names { get; set; } = null!;

        public string Lastnames { get; set; } = null!;

        public string TypeDocument { get; set; } = null!;

        public string Document { get; set; } = null!;

        public int RoleId { get; set; }

        public string Avatar { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Cellphone { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public DateTime Birthday { get; set; }
    }
}
