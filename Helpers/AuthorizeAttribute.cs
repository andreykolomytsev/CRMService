using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using CRMService.DTOModels;

namespace CRMService.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var account = (Account)context.HttpContext.Items["Account"];

            if (account == null) // not logged in - not authorized
            {
                context.Result = new JsonResult(new { message = "Требуется авторизация" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            //else if (_roles.Any() && !_roles.Contains(account.Role))
            //{
            //    context.Result = new JsonResult(new { message = "У Вас нет доступа" }) { StatusCode = StatusCodes.Status403Forbidden };
            //}
        }
    }
}
