using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Models;

public class Movie
{
    [Comment("Movie identifier")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Comment("Movie title")]
    public string Title { get; set; } = null!;

    [Comment("Movie genre")]
    public string Genre { get; set; } = null!;

    [Comment("Movie release date")]
    public DateTime ReleaseDate { get; set; }

    [Comment("Movie director")]
    public string Director { get; set; } = null!;

    [Comment("Movie duration")]
    public int Duration { get; set; }

    [Comment("Movie description")]
    public string Description { get; set; } = null!;

    [Comment("Movie image url from the image store")]
    public string? ImageUrl { get; set; }

    // TODO: Extract the property with Id to BaseDeletableModel
    [Comment("Shows if movie is deleted")]
    public bool IsDeleted { get; set; }

    public virtual ICollection<CinemaMovie> CinemaMovies { get; set; } = new HashSet<CinemaMovie>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

    public virtual ICollection<Watchlist> UserWatchlists { get; set; } = new HashSet<Watchlist>();

}
