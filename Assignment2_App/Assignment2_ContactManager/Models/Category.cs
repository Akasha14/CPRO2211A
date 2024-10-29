using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2_ContactManager.Models
{
    // Had to make properties nullable in order for them to work.

    public class Category
    {
        public int categoryId {  get; set; }

        [Required]
        public string? name { get; set; }
    }
}
