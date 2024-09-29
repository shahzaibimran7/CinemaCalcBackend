namespace CinemaCalc.API.Models;

public class ExpenseSummaryResponse
{
    public List<Expense> Expenses { get; set; } = [];
    public decimal TotalSum { get; set; }
}