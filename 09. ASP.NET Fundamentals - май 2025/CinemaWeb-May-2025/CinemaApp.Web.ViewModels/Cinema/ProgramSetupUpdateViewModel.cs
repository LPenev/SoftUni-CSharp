namespace CinemaApp.Web.ViewModels.Cinema;

public class ProgramSetupUpdateViewModel
{
    public int CinemaId { get; set; }

    public List<ProgramMovieViewModel> Movies { get; set; } = new();
}

