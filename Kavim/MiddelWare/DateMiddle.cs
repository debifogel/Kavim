namespace Kavim.Api.MiddelWare
{
    public class DateMiddle
    {
        private readonly RequestDelegate _next;
        DateMiddle(RequestDelegate next)
    {
        _next = next;
       
    }
        public async Task InvokeAsync(HttpContext context)
        {
            if (DateTime.Now.DayOfWeek!=DayOfWeek.Saturday)
                await _next(context);
        }
    }
}
