﻿using Microsoft.AspNetCore.Identity;

namespace CinemaApp.Data.Models;

public class UserTicket
{
    public string UserId { get; set; } = null!;

    public virtual IdentityUser User { get; set; } = null!;

    public Guid TicketId { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;
}

