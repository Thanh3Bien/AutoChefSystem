using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string? Phone { get; set; }

    public string Content { get; set; } = null!;

    public int? OrderId { get; set; }

    public int? Rating { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Customer? PhoneNavigation { get; set; }
}
