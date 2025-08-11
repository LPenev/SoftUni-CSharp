namespace BookVerse.ViewModels.Book;

public class MyBooksViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? CoverImageUrl { get; set; }
    public string Genre { get; set; } = null!;
}

