using CinemaApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers;

public class MovieController : Controller
{
    private readonly CinemaAppDbContext context;

    public MovieController(CinemaAppDbContext context)
    {
        this.context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
}
