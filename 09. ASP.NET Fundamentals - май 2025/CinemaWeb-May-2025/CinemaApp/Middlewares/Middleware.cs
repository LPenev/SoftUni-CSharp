namespace CinemaApp.Web.Middlewares
{
    public class ManagerAccessMiddleware
    {
        private readonly RequestDelegate _next;

        public ManagerAccessMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString().ToLower();
            var isManagerPath = path.StartsWith("/manager");

            if (isManagerPath)
            {
                var user = context.User;
                if (!user.Identity?.IsAuthenticated ?? true || !user.IsInRole("Manager"))
                {
                    context.Response.Redirect("/Home/AccessDenied");
                    return;
                }

                await _next(context);
            }
        }
    }
}
