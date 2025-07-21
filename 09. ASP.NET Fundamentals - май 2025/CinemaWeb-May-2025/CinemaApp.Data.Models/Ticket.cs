using Microsoft.AspNetCore.Identity;

namespace CinemaApp.Data.Models;

public class Ticket
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public decimal Price { get; set; }

    public Guid? CinemaId { get; set; }

    public virtual Cinema? Cinema { get; set; }

    public Guid? MovieId { get; set; }

    public virtual Movie? Movie { get; set; }

    public string UserId { get; set; } = null!;

    public virtual IdentityUser User { get; set; } = null!;
}