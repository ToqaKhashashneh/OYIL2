using System;
using System.Collections.Generic;

namespace Employment.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Image { get; set; }

    public int? MangerId { get; set; }

    public virtual ICollection<AssignTask> AssignTasks { get; set; } = new List<AssignTask>();

    public virtual Manager? Manger { get; set; }
}
