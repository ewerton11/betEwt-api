using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.Models;

public class UserModels
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [StringLength(15, MinimumLength = 3, ErrorMessage = "The User must be between 3 and 15 characters long.")]
    [Required(ErrorMessage = "The User field is mandatory.")]    
    public string? user { get; set; }

    [StringLength(30, MinimumLength = 3, ErrorMessage = "The Password must be between 3 and 30 characters long.")]
    [Required(ErrorMessage = "The Password field is mandatory.")]
    public string? passwordHash { get; set; }

    public DateTime created_at { get; set; } = DateTime.Now;
}