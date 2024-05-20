using System.Diagnostics;
using project;
namespace project
{
    public class MyLogMiddleware
    {
        private readonly RequestDelegate next;
        private string path;
        public MyLogMiddleware(RequestDelegate next, IWebHostEnvironment webHost)
        {
            this.next = next;
            this.path = Path.Combine(webHost.ContentRootPath, "Data", "myLogMiddleware.txt");
        }

        public async Task Invoke(HttpContext c)
        {
            //תוכן של המידלוואר
            DateTime dateTime=DateTime.Now;
            var sw = new Stopwatch();
            sw.Start();
            await next.Invoke(c);
            if (File.Exists(path))
            {
                string createText = $"{c.Request.Path}.{c.Request.Method} took {sw.ElapsedMilliseconds}ms. dateTime{dateTime}"
                + $" User: {c.User?.FindFirst("userId")?.Value ?? "unknown"}" + Environment.NewLine;
                File.AppendAllText(path, createText);
            }
        }
    }   
}
public static partial class MiddlewareExtensions
{
    public static IApplicationBuilder UseMyLogMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyLogMiddleware>();
    }
}
