using System.ComponentModel.DataAnnotations;

namespace BetsApi.Models;

public class BetsModels
{
    public int id { get; set; }

    [MaxLength(20, ErrorMessage = "The Title field must have a maximum of 20 characters.")]
    [Required(ErrorMessage = "The Title field is mandatory.")]
    public string? title { get; set; }

    [Range(0, 999.99, ErrorMessage = "The Price field must be between 0 and 999.99.")]
    [Required(ErrorMessage = "The Price field is mandatory.")]
    public decimal price { get; set; }

    [MaxLength(200, ErrorMessage = "The Description field must have a maximum of 200 characters.")]
    [Required(ErrorMessage = "The Description field is mandatory.")]
    public string? description { get; set; }

    public DateTime created_at { get; set; } = DateTime.Now;
}