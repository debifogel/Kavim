using System.Runtime.CompilerServices;

namespace Kavim.Api.MiddelWare
{
    public static class ExtaraMiddaleWare
    {
        public static void UseCheckDate(this IApplicationBuilder app)
        {
            app.UseMiddleware<DateMiddle>();
        }
    }
}
