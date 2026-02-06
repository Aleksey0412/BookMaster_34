using System;
using System.Collections.Generic;

namespace BookMaster_34.Models;

public partial class Book
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Subtitle { get; set; }

    public DateOnly? FirstPublishDate { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    public virtual ICollection<BookCover> BookCovers { get; set; } = new List<BookCover>();

    public virtual ICollection<BookSubject> BookSubjects { get; set; } = new List<BookSubject>();

    public virtual ICollection<Circulation> Circulations { get; set; } = new List<Circulation>();
}
