﻿namespace BookVerse.ViewModels.Book;

public class BookViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? CoverImageUrl { get; set; }

    public string Genre { get; set; } = null!;

    public int SavedCount { get; set; }

    public bool IsSaved { get; set; }

    public bool IsAuthor { get; set; }
}

