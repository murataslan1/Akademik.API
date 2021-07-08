using System.Linq;
using System.Net;
using System.Net.Http;
using Akademik.API.Classes.Constants;
using Akademik.API.Classes.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Akademik.API.Classes.Filters
{
    public class JwtHandler : ActionFilterAttribute
    {
      
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.All(b => b.Key != JwtConstants.TokenKey) ||
                !context.HttpContext.Request.Headers.FirstOrDefault(b => b.Key == JwtConstants.TokenKey).Value
                    .ToString().CheckIsValidJwtParameter())
                context.Result = new UnauthorizedResult();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}