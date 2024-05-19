using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class TaskEvent
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DueDate { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

    }
}
