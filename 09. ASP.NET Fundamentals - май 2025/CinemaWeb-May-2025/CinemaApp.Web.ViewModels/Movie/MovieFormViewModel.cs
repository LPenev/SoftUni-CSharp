namespace CinemaApp.Web.ViewModels.Movie
{
    using System.ComponentModel.DataAnnotations;
    using static CinemaApp.Data.Common.EntityConstants.Movie;

    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            this.ReleaseDate = DateTime.UtcNow.ToString(ReleaseDateFormat);
        }

        [Required(ErrorMessage = TitleRequiredErrorMessage)]
        [MinLength(TitleMinLength, ErrorMessage = TitleMinLengthMessage)]
        [MaxLength(TitleMaxLength, ErrorMessage = TitleMaxLengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = GenreRequiredErrorMessage)]
        [MinLength(GenreMinLength, ErrorMessage = GenreMinLengthMessage)]
        [MaxLength(GenreMaxLength, ErrorMessage = GenreMaxLengthErrorMessage)]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = ReleaseDateRequiredErrorMessage)]
        public string ReleaseDate { get; set; }

        [Required(ErrorMessage = DurationRequiredErrorMessage)]
        [Range(DurationMin, DurationMax, ErrorMessage = DurationRangeMessage)]
        public int Duration { get; set; }

        [Required(ErrorMessage = DirectorRequiredErrorMessage)]
        [MinLength(DirectorNameMinLength, ErrorMessage = DirectorNameMinLengthMessage)]
        [MaxLength(DirectorNameMaxLength, ErrorMessage = DirectorMaxLengthErrorMessage)]
        public string Director { get; set; } = null!;

        [Required(ErrorMessage = DescriptionRequiredErrorMessage)]
        [MinLength(DescriptionMinLength, ErrorMessage = DescriptionMinLengthMessage)]
        [MaxLength(DescriptionMaxLength, ErrorMessage = DescriptionMaxLengthErrorMessage)]
        public string Description { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength, ErrorMessage = ImageUrlMaxLengthMessage)]
        public string? ImageUrl { get; set; }

        public string? Id { get; set; }
    }
}
