using System;
using System.Collections.Generic;

namespace KitStemHub.Repositories.Models;

public partial class Method
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string NormalizedName { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
