using System;
using System.Collections.Generic;

namespace BookMaster_34.Models;

public partial class BookSubject
{
    public int BookSubjectId { get; set; }

    public string BookId { get; set; } = null!;

    public int SubjectId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
