﻿using Microsoft.AspNetCore.Identity;

namespace BookVerse.DataModels;
public class UserBook
{
    public string UserId { get; set; } = null!;
    public IdentityUser User { get; set; } = null!;

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}
