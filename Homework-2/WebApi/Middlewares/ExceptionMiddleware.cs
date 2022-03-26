using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApi.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new System.NotImplementedException();
        }
    }
}
