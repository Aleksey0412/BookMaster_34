using System;
using System.Collections.Generic;

namespace BookMaster_34.Models;

public partial class BookAuthor
{
    public int BookAuthorId { get; set; }

    public string BookId { get; set; } = null!;

    public int AuthorId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;
}
