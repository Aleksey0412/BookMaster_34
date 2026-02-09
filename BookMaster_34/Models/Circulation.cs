using System;
using System.Collections.Generic;

namespace BookMaster_34.Models;

public partial class Circulation
{
    public int Id { get; set; }

    public string BookId { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public DateOnly DateOfIssue { get; set; }

    public DateOnly DateOfReturn { get; set; }

    public int AdministratorId { get; set; }

    public bool IsBookReturned { get; set; }

    public virtual Administrator Administrator { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
