using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers;

[Authorize]
public abstract class BaseController : Controller
{
    protected bool IsUserAuthenticated()
    {
        return User.Identity?.IsAuthenticated ?? false;
    }
    
    protected string? GetUserId()
    {
        return User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier) ?? string.Empty;
    }
}

