namespace ECommerce.Application.Common;

public class ApiResponse
{
    public int Code { get; set; }
    public string Message { get; set; } = null!;
    public object? Data { get; set; }

    public static ApiResponse Success(object? data = null, string message = "Success")
    {
        return new ApiResponse { Code = 200, Message = message, Data = data };
    }

    public static ApiResponse Fail(string message, int code = 400)
    {
        return new ApiResponse { Code = code, Message = message, Data = null };
    }
}
