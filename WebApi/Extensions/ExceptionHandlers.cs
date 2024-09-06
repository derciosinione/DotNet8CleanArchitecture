namespace WebApi.Extensions;

public abstract class ExceptionHandlers
{
    public static async Task MiddlewareFilter(Func<Task> func, HttpContext httpContext)
    {
        try
        {
            await func();
        }
        catch (Exception e)
        {
            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsync("Internal server error");
            Console.WriteLine(e.Message);
        }
    }
}