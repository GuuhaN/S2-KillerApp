using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using S2_KillerApp_ASPNET.Data_Contexts;
using S2_KillerApp_ASPNET.Repositories;
using Microsoft.AspNetCore.Mvc;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Controllers
{
    public class UserController : Controller
    {
        private IUserContext userContext;
        private UserRepository userRepository;

        private IPlaylistContext playlistContext;
        private PlaylistRepository playlistRepository;

        public UserController()
        {
            userContext = new UserSQLContext();
            userRepository = new UserRepository(userContext);

            playlistContext = new PlaylistSQLContext();
            playlistRepository = new PlaylistRepository(playlistContext);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password)
        {
            IActionResult result = null;

            UserViewModel userViewModel = new UserViewModel();
            if (username == string.Empty || password == string.Empty || username == null || password == null)
            {
                ViewBag.Message = "Please fill in valid credentials.";
                result = View();
            }
            else
            {
                userViewModel.User = userRepository.GetUserCredentials(username, password);
                try
                {
                    //if (userViewModel.User.loggedIn)
                    //    return Content("User already logged in.");

                    if (userViewModel.User.Username == username &&
                        userViewModel.User.Password == password)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, userViewModel.User.Username),
                            new Claim(ClaimTypes.Email, userViewModel.User.Email),
                            new Claim(ClaimTypes.NameIdentifier, userViewModel.User.Id.ToString()),
                            new Claim(ClaimTypes.Role, userViewModel.User.Role)
                        };

                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principle = new ClaimsPrincipal(userIdentity);

                        AuthenticationProperties authenticationProperties = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            AllowRefresh = true,
                            ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(1)),
                            RedirectUri = "Landing/Login/"
                        };

                        await HttpContext.SignInAsync(principle, authenticationProperties);
                        return RedirectToAction("Main", "Music");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Incorrect username or password, please try again";
                    result = View();
                }
            }

            return result;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Register(string username, string email, string password, string confirm)
        {
            if (password == confirm)
            {
                userRepository.AddUser(username, password, email);
                ViewBag.Message = "Successfully registed !";
            }
            else
                ViewBag.Message = "Please fill in the correct information.";

            return View();
        }

        [HttpGet, Authorize(Policy = "RegisteredUser")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}