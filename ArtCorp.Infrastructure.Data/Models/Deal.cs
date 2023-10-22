using System;
using System.Collections.Generic;

namespace ArtCorp.Infrastructure.Data.Models;

public partial class Deal
{
    public int Id { get; set; }

    public int ProposalId { get; set; }

    public int ClientId { get; set; }

    public int ArtistId { get; set; }

    public int PostId { get; set; }

    public int State { get; set; }

    public decimal Price { get; set; }

    public DateTime DateUpdated { get; set; }

    public virtual User Artist { get; set; } = null!;

    public virtual User Client { get; set; } = null!;

    public virtual Proposal Proposal { get; set; } = null!;
}
