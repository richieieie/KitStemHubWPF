using System;
using System.Collections.Generic;

namespace KitStemHub.Repositories.Models;

public partial class KitOrder
{
    public int KitId { get; set; }

    public Guid OrderId { get; set; }

    public int? KitQuantity { get; set; }

    public virtual Kit Kit { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
