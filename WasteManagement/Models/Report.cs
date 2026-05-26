using System.ComponentModel.DataAnnotations;
namespace WasteManagement.Models
{
    public class Report
    {
       
            public int ReportId { get; set; }

            [Required]
            [StringLength(100)]
            public string? Title { get; set; }

            [Required]
            [StringLength(500)]
            public string? Description { get; set; }

            [Required]
            public string? Location { get; set; }

            public string? ImageUrl { get; set; }

            public string? UserId { get; set; }

            public string Status { get; set; } = "Pending";

            public DateTime DateReported { get; set; } = DateTime.Now;
        
    }
}


