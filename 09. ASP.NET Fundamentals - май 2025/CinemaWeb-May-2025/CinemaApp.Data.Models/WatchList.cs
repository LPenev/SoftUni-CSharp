using Microsoft.AspNetCore.Identity;

namespace CinemaApp.Data.Models;

public class Watchlist
{
    public string UserId { get; set; } = null!;
    public virtual IdentityUser User { get; set; } = null!;
    public Guid MovieId { get; set; }
    public virtual Movie Movie { get; set; } = null!;

    public bool IsDeleted { get; set; }
}
