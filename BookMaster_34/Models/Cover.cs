using System;
using System.Collections.Generic;

namespace BookMaster_34.Models;

public partial class Cover
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public virtual ICollection<BookCover> BookCovers { get; set; } = new List<BookCover>();
}
