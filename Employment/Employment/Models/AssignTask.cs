using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employment.Models;

public partial class AssignTask
{
    public int Id { get; set; }
    [Required (ErrorMessage ="This field is required")]
    public string? TaskName { get; set; }


    [Required(ErrorMessage = "This field is required")]

    public DateOnly? StartDate { get; set; }
    [Required(ErrorMessage = "This field is required")]

    public DateOnly? EndDate { get; set; }

    public int? EmplyeeId { get; set; }

    public virtual Employee? Emplyee { get; set; }
}
