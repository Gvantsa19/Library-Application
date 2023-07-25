using Microsoft.AspNetCore.Authorization;

namespace Library.Application.API
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthAttribute : AuthorizeAttribute, IAuthorizeData
    {
    }
}
