using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public string? Phone { get; set; }

    public string? Status { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Customer? PhoneNavigation { get; set; }
}
