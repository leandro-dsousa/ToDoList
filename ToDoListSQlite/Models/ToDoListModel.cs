using System;
using System.Collections.Generic;

namespace ToDoList.Models;

public partial class ToDoListModel
{
    public long Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? AddedOn { get; set; }

    public string? DueDate { get; set; }
}
