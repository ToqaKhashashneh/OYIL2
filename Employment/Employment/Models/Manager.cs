using System;
using System.Collections.Generic;

namespace Employment.Models;

public partial class Manager
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Department { get; set; }

    public string? Email { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
