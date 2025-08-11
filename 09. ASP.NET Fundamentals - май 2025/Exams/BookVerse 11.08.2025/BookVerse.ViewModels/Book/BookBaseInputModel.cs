using System.ComponentModel.DataAnnotations;
using static BookVerse.GCommon.ValidationConstants.Book;

namespace BookVerse.ViewModels.Book
{
    public class BookBaseInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;
        public int GenreId { get; set; }
        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        public string? CoverImageUrl { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; } = Enumerable.Empty<GenreViewModel>();
    }
}
