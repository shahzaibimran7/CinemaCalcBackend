using System.ComponentModel.DataAnnotations;

namespace CinemaCalc.API.Models;

public class CreateUpdateExpenseRequest(decimal percentageMarkup, decimal price, string name)
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(64, ErrorMessage = "Name cannot be longer than 64 characters.")]
    public string Name { get; } = name;

    [Required(ErrorMessage = "Price is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; } = price;

    [Required(ErrorMessage = "PercentageMarkup is required.")]
    [Range(0, 100, ErrorMessage = "PercentageMarkup must be between 0 and 100.")]
    public decimal PercentageMarkup { get; } = percentageMarkup;
}