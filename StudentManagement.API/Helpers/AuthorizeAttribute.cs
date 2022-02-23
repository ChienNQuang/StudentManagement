using System;
using StudentManagement.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentManagement.API.Helpers
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // User user = (User)context.HttpContext.Items["User"];

            // if (user is null)
            // {
            //     context.Result = new JsonResult(new { Message = "Unauthorized" })
            //                         { StatusCode = StatusCodes.Status401Unauthorized};
            // }
        }
    }
}