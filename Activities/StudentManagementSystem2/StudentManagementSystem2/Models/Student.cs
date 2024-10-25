using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem2.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        // Array of email addresses.
        public List<string> Emails { get; set; } = new List<string>();

    }
}
