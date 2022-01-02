using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using CRMService.Interfaces;

namespace CRMService.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJWTService jWTService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            
            // Проверям действительность полученного токена
            var account = jWTService.ValidateToken(token);
            
            if (account != null)
            {
                // Добавляем данные аккаунта к контексту при успешной JWT валидации 
                context.Items["Account"] = account;
            }

            await _next(context);
        }
    }
}
