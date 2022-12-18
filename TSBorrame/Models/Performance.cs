using System;
using System.Collections.Generic;

namespace TSBorrame.Models;

public partial class Performance
{
    public int PerformanceId { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;
}
