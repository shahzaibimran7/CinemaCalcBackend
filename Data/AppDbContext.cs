using CinemaCalc.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaCalc.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Expense> Expenses { get; set; }
}