using System;
using System.Collections.Generic;

namespace ArtCorp.Infrastructure.Data.Models;

public partial class SalePost
{
    public int Id { get; set; }

    public string Img { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int ArtistId { get; set; }

    public decimal Price { get; set; }

    public int State { get; set; }

    public int ClientId { get; set; }

    public virtual User Artist { get; set; } = null!;

    public virtual User Client { get; set; } = null!;
}
