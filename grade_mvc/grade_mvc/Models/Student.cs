using grade_mvc.enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace grade_mvc.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
      
        public string Phone { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
