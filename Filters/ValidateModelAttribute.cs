using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CinemaCalc.API.Models;

namespace CinemaCalc.API.Filters;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid) return;
        
        var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
        context.Result = new BadRequestObjectResult(new ApiResponse
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Message = "Invalid payload",
            Data = errors
        });
    }
}