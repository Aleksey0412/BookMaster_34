using System;
using System.Collections.Generic;

namespace BookMaster_34.Models;

public partial class Customer
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int? CityId { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Zip { get; set; }

    public virtual ICollection<Circulation> Circulations { get; set; } = new List<Circulation>();

    public virtual City? City { get; set; }
}
