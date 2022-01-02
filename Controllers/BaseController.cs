using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRMService.DTOModels;

namespace CRMService.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        //реализации проверки авторизации
        public Account Account => (Account)HttpContext.Items["Account"];
    }
}
