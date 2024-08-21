using Lms.BusinessLogic.Abstract;
using Lms.BusinessLogic.Dtos;
using Lms.BusinessLogic.Enums;
using Lms.Core.Utils;
using Lms.ExternalServices.Interfaces;
using Lms.UI.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace Lms.UI.Areas.Auth.Controllers
{
    [Area("auth")]
    public class AuthenticationController : Controller
    {

        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AuthenticationController(IUserService userService,
                                        IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<IActionResult> Register()
        {
            CreateUserDto userDto = new();
            return View(userDto);
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserDto userDto)
        {
            var result = await _userService.CreatedUser(userDto);

            if (result.ResponseValidationResults.Count > 0)
            {
                foreach (var item in result.ResponseValidationResults)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }


                var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { success = false, errors });
            }

            string url = $"http://localhost:5226/auth/authentication/ConfirEmail?code={result.Data.ConfirmCode}&userId={result.Data.Id}";
            await _emailService.SendEmailAsync(result.Data.Email, "Confirm Email", MessageGenerators.ConfirmMessage("Confirm email for complete register", url));

            return RedirectToAction("EmailConfirmationPage","Authentication");
        }


        [HttpGet]

        public IActionResult EmailConfirmationPage()
        {
           return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirEmail(int code, int userId)
        {
            var result = await _userService.CheckConfirmCode(code);

            if (result.Data is true)
            {
                await _userService.ChangeUserStatus(RegisterStatusEnum.Deactive, userId);
                return Redirect("/auth/authentication/signin");
            }
            return Json("");
        }

        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            SigninUserDto signinUserDto = new SigninUserDto();
            return View(signinUserDto);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SigninUserDto userDto)
        {
            var result = await _userService.CheckUserAsync(userDto);

            if (result.ResponseValidationResults.Count > 0)
                {
                foreach (var item in result.ResponseValidationResults)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }


                var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return Json(new { success = false, errors });
            }


            if (result.Data != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userDto.Email),
                    new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Worker"),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)

                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                return Redirect("/admin/book/index");
            }
            return View(userDto);

        }
    }
}
