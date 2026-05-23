using System.ComponentModel.DataAnnotations;
namespace WasteManagement.Models
{
    public class Report
    {
       
            public int ReportId { get; set; }

            [Required]
            public string? Title { get; set; }

            [Required]
            public string? Description { get; set; }

            public string? Location { get; set; }

            public string? ImageUrl { get; set; }

            public string Status { get; set; } = "Pending";

            public DateTime DateReported { get; set; } = DateTime.Now;
        
    }
}

