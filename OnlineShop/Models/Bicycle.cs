using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class Bicycle
    
{
    public int Id { get; set; }
    public string? Model { get; set; }

    public string? Typeb { get; set; }

    public string? Countrycreator { get; set; }

    public int? Yearc { get; set; }

    public int? Price { get; set; }
}
