using System.ComponentModel.DataAnnotations;

namespace ivoApi.Models.Dtos;

public class CreateConfigAppDto
{
    [Required]
    [StringLength(45, MinimumLength = 3)]
    public string ReportName { get; set; } = string.Empty;

    [Required]
    public string PathIn { get; set; } = string.Empty;

    [Required]
    public string PathOut { get; set; } = string.Empty;

    [Required]
    [Range(0, 1)]
    public int? FlagAtivo { get; set; }
}