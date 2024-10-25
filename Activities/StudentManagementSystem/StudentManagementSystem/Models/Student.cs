using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Key] // This marks the property as the primary key
        public int Id { get; set; }

        public required string Name { get; set; }

        public int Age { get; set; }

        public string Course { get; set; }
    }
}
