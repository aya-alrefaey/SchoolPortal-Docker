using grade_mvc.enums;

namespace grade_mvc.Viewmodels
{
    public class GradeViewModel
    {
        
        public int GradeId { get; set; }
        public string CourseName { get; set; } 
        public double Score { get; set; }
        public DateTime GradeDate { get; set; }
        public string Notes { get; set; } 


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }

        public string Phone { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
