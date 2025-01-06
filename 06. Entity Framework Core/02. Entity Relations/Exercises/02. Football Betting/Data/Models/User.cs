﻿namespace P02_FootballBetting.Data.Models;
public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public decimal Balance { get; set; }
}

