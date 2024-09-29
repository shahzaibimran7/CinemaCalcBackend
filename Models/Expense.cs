using System.ComponentModel.DataAnnotations;

namespace CinemaCalc.API.Models;

public class Expense
{
    [Key]
    public int ExpenseId { get; init; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [Range(0, 100)]
    public decimal PercentageMarkup { get; set; }

    [Required]
    public decimal TotalPrice { get; set; }
}