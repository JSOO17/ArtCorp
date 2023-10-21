using System;
using System.Collections.Generic;

namespace ArtCorp.Infrastructure.Data.Models;

public partial class Post
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int Material { get; set; }

    public int TypePint { get; set; }

    public int Size { get; set; }

    public decimal InitialPrice { get; set; }

    public int Border { get; set; }

    public string? Description { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
}
