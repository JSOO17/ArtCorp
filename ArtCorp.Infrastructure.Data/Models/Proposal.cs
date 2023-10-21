using System;
using System.Collections.Generic;

namespace ArtCorp.Infrastructure.Data.Models;

public partial class Proposal
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int PostId { get; set; }

    public int State { get; set; }

    public decimal Price { get; set; }

    public string Comment { get; set; } = null!;

    public virtual User Client { get; set; } = null!;

    public virtual ICollection<Deal> Deals { get; set; } = new List<Deal>();

    public virtual Post Post { get; set; } = null!;
}
