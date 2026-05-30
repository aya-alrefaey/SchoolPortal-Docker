using student_mvc.enums;
using System.ComponentModel.DataAnnotations;

namespace student_mvc.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Invalid Egyptian phone number")]
        public string Phone{ get; set; }
        public DateTime EnrollmentDate { get; set; }

        
      

    }
}
