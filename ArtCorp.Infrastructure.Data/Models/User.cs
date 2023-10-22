using System;
using System.Collections.Generic;

namespace ArtCorp.Infrastructure.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Names { get; set; } = null!;

    public string Lastnames { get; set; } = null!;

    public string TypeDocument { get; set; } = null!;

    public string Document { get; set; } = null!;

    public string Cellphone { get; set; } = null!;

    public int RoleId { get; set; }

    public string Avatar { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime Birthday { get; set; }

    public virtual ICollection<Deal> DealArtists { get; set; } = new List<Deal>();

    public virtual ICollection<Deal> DealClients { get; set; } = new List<Deal>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SalePost> SalePostArtists { get; set; } = new List<SalePost>();

    public virtual ICollection<SalePost> SalePostClients { get; set; } = new List<SalePost>();
}
