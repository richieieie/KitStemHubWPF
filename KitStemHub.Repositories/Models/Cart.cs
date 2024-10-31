using System;
using System.Collections.Generic;

namespace KitStemHub.Repositories.Models;

public partial class Cart
{
    public Guid UserId { get; set; }

    public int KitId { get; set; }

    public int? Quantity { get; set; }

    public virtual Kit Kit { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
