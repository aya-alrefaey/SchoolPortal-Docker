using System.ComponentModel.DataAnnotations;

namespace grade_mvc.Models
{
    public class Grade
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [MaxLength(50)]
        public string CourseName { get; set; } 

        [Required(ErrorMessage = "Score is required")]
        [Range(0, 100, ErrorMessage = "Score must be between 0 and 100")]
        public double Score { get; set; }
        [Required(ErrorMessage = "Grade Date is required")]
        public DateTime GradeDate { get; set; } = DateTime.Now;
        public string? Notes { get; set; }

    }
}
