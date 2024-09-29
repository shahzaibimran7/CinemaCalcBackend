namespace CinemaCalc.API.Models;

public class ApiResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public object? Data { get; set; }

    public static ApiResponse CreatedSuccessfully()
    {
        return new ApiResponse
        {
            StatusCode = StatusCodes.Status201Created,
            Message = "Created successfully",
        };
    }

    public static ApiResponse UpdatedSuccessfully()
    {
        return new ApiResponse
        {
            StatusCode = StatusCodes.Status201Created,
            Message = "Updated successfully",
        };
    }

    public static ApiResponse DeletedSuccessfully()
    {
        return new ApiResponse
        {
            StatusCode = StatusCodes.Status204NoContent,
            Message = "Deleted successfully",
        };
    }

    public static ApiResponse RetrievedSuccessfully(object data)
    {
        return new ApiResponse
        {
            StatusCode = StatusCodes.Status200OK,
            Message = "Retrieved successfully",
            Data = data
        };
    }
    
    public static ApiResponse NotFound()
    {
        return new ApiResponse
        {
            StatusCode = StatusCodes.Status404NotFound,
            Message = "Not found",
        };
    }
}