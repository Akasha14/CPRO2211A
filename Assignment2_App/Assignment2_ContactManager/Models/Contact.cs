using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2_ContactManager.Models
{
    // Had to make properties nullable in order for them to work.

    public class Contact
    {
        public int contactId { get; set; }

        [Required]
        public string? firstName { get; set; }

        [Required] 
        public string? lastName { get; set; }

        [Required, EmailAddress]
        public string? email { get; set; }

        [Required]
        public string? phoneNumber { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int categoryId { get; set; }

        // Each contact has a category.
        public Category? Category { get; set; }

        public string? organization { get; set; }

        public DateTime dateAdded { get; set; } = DateTime.Now;

        // Read-only slug property.
        public string Slug => $"{firstName}-{lastName}".ToLower();

    }
}
