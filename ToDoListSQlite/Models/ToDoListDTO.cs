using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoListDTO
    {

        public string id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? addedOn { get; set; }

        public string? dueDate { get; set; }

    }
}
