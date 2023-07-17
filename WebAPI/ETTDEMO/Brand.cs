﻿using System;
using System.Collections.Generic;

namespace WebApi.ETTDEMO;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
