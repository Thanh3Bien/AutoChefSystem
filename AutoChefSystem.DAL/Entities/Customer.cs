using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class Customer
{
    public string Phone { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
