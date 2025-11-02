namespace Week_3_Inno_PreTrainee.Middleware
{
    public class ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger
    )
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception:{Messege}", ex.Message);
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
    public static class ExceptionHandlingMiddlewareExtasion
    {
        public static IApplicationBuilder UseException(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
