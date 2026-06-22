using System.ComponentModel.DataAnnotations;
namespace WasteManagement.Models
{
        public class Worker
        {
            public int WorkerId { get; set; }

        [Required]

        public string? Name { get; set; }

         [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Email { get; set; }
        }
    
}

