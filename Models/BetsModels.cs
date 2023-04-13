using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetsApi.Models;

public class BetsModels
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [StringLength(20, MinimumLength = 3, ErrorMessage = "The Title must be between 3 and 20 characters long.")]
    [Required(ErrorMessage = "The Title field is mandatory.")]
    public string? title { get; set; }

    [Column(TypeName = "decimal(3,2)")]
    [Range(0, 999.99, ErrorMessage = "The Price field must be between 0 and 999.99.")]
    [Required(ErrorMessage = "The Price field is mandatory.")]
    public decimal price { get; set; }

    [StringLength(200, MinimumLength = 5, ErrorMessage = "The Description must be between 5 and 200 characters long.")]
    [Required(ErrorMessage = "The Description field is mandatory.")]
    public string? description { get; set; }

    public DateTime created_at { get; set; } = DateTime.Now;
}