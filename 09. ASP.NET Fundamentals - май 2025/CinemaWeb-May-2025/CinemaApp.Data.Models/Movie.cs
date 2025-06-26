using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CinemaApp.GCommon.EntityConstants.Movie;

namespace CinemaApp.Data.Models;

public class Movie
{
    [Comment("Movie Identifier")]
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Comment("Movie Title")]
    [Required(ErrorMessage = TitleRequiredErrorMessage)]
    [StringLength(TitleMaxLength)]
    public string Title { get; set; } = null!;
    
    [Comment("Movie Genre")]
    [Required(ErrorMessage = GenreRequiredErrorMessage)]
    [StringLength(GenreMaxLength, ErrorMessage = GenreMaxLengthErrorMessage)]
    public string Genre { get; set; } = null!;
    
    [Comment("Movie Release Date")]
    [Required(ErrorMessage = ReleaseDateRequiredErrorMessage)]
    public DateTime ReleaseDate { get; set; }
    
    [Comment("Movie Director")]
    [Required(ErrorMessage = DirectorRequiredErrorMessage)]
    [StringLength(DirectorMaxLength, ErrorMessage = DirectorMaxLengthErrorMessage)]
    public string Director { get; set; } = null!;
    
    [Required(ErrorMessage = DurationRequiredErrorMessage)]
    public int Duration { get; set; }
    
    [Required(ErrorMessage = DescriptionRequiredErrorMessage)]
    [StringLength(DescriptionMaxLength, ErrorMessage = DescriptionMaxLengthErrorMessage)]
    public string Description { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public bool IsDeleted { get; set; }
}
