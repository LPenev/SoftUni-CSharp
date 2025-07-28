namespace CinemaApp.Web.ViewModels.Cinema;

public class ProgramMovieViewModel
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public int Duration { get; set; }

    public string PosterUrl { get; set; } = null!;

    public bool IsIncluded { get; set; }
}

