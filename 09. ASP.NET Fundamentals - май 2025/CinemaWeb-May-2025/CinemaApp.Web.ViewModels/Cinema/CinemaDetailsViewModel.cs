using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Web.ViewModels.Cinema;

public class CinemaDetailsViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public List<CinemaMovieViewModel> Movies { get; set; } = new();
}
