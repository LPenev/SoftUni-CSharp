namespace CinemaApp.Data.Models;

public class CinemaMovie
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid? MovieId { get; set; }
    public virtual Movie? Movie { get; set; }

    public Guid? CinemaId { get; set; }
    public virtual Cinema? Cinema { get; set; }

    public int AvailableTickets { get; set; }

    public bool IsDeleted { get; set; } = false;

    public string Showtimes { get; set; } = "00000";
}

