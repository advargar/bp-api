using System.Security.Claims;
using polizas_api.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using polizas_api.Services;
using System.Data.SqlClient;

namespace polizas_api.Controllers
{
    public class LoginController : Controller
    {
        private readonly projectContext _context;
        private readonly IUserService _userService;

        public LoginController(IUserService userService, projectContext context)
        {
            _userService = userService;
            _context = context;
        }

        public IActionResult Login()
        {
            ClaimsPrincipal c = HttpContext.User;
            if (c.Identity != null)
            {
                if (c.Identity.IsAuthenticated)
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }

       
    }
}
