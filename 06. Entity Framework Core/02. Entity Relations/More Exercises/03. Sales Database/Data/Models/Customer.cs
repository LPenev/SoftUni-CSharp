﻿namespace P03_SalesDatabase.Data.Models;

public class Customer
{
    public Customer()
    {
        this.Sales = new HashSet<Sale>();
    }

    public int CustomerId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; }
    public string CreditCardNumber {  get; set; }

    public virtual ICollection<Sale> Sales { get; set; }
}
