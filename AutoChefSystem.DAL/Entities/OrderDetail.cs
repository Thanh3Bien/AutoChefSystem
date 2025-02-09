using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? DishId { get; set; }

    public int Quantity { get; set; }

    public virtual Dish? Dish { get; set; }

    public virtual Order? Order { get; set; }
}
