using CinemaCalc.API.Data;
using CinemaCalc.API.Filters;
using CinemaCalc.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaCalc.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController(AppDbContext context) : ControllerBase
{
    // GET: api/Expenses
    [HttpGet]
    public async Task<IActionResult> GetExpenses()
    {
        var expenses = await context.Expenses.ToListAsync();
        var totalSum = expenses.Sum(e => e.TotalPrice);

        var response = new ExpenseSummaryResponse
        {
            Expenses = expenses,
            TotalSum = totalSum
        };
        
        return Ok(ApiResponse.RetrievedSuccessfully(response));
    }
    
    // GET: api/Expenses/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetExpense(int id)
    {
        var expense = await context.Expenses.FindAsync(id);

        if (expense == null)
            return NotFound(ApiResponse.NotFound());
        
        return Ok(ApiResponse.RetrievedSuccessfully(expense));
    }
    
    // POST: api/Expenses
    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> CreateExpense([FromBody] CreateUpdateExpenseRequest request)
    {
        var expense = new Expense
        {
            Name = request.Name,
            Price = request.Price,
            PercentageMarkup = request.PercentageMarkup,
            TotalPrice = request.Price + request.Price * request.PercentageMarkup / 100
        };

        context.Expenses.Add(expense);
        await context.SaveChangesAsync();

        return Ok(ApiResponse.CreatedSuccessfully());
    }
    
    // PUT: api/Expenses/{id}
    [HttpPut("{id:int}")]
    [ValidateModel]
    public async Task<IActionResult> UpdateExpense(int id, [FromBody] CreateUpdateExpenseRequest request)
    {
        var expense = await context.Expenses.FindAsync(id);

        if (expense == null)
            return NotFound(ApiResponse.NotFound());

        // Update the expense properties
        expense.Name = request.Name;
        expense.Price = request.Price;
        expense.PercentageMarkup = request.PercentageMarkup;
        expense.TotalPrice = request.Price + request.Price * request.PercentageMarkup / 100;

        context.Entry(expense).State = EntityState.Modified;

        await context.SaveChangesAsync();

        return Ok(ApiResponse.UpdatedSuccessfully());
    }
    
    // DELETE: api/Expenses/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var expense = await context.Expenses.FindAsync(id);

        if (expense == null)
            return NotFound(ApiResponse.NotFound());

        context.Expenses.Remove(expense);
        await context.SaveChangesAsync();

        return Ok(ApiResponse.DeletedSuccessfully());
    }
}