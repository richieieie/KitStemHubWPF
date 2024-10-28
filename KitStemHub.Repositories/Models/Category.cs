using System;
using System.Collections.Generic;

namespace KitStemHub.Repositories.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<Kit> Kits { get; set; } = new List<Kit>();
}
