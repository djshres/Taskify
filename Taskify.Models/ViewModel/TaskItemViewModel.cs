using System.ComponentModel.DataAnnotations;
using Taskify.Models.Enum;

namespace Taskify.Models.ViewModel
{
    public class TaskItemViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required]
        public Priority Priority { get; set; }
    }
}
