using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace PollingSystem.Web.Pages.Admin
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }


        public string Returnurl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = null;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = null;

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }

        }

        public async Task OnGetAsync(string? returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ReturnUrl = returnUrl;
        }
        
        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var password = "123qwerty";
            var email = "microservice@yopmail.com";
            if (Input.Password != password || Input.Email != email)
            {
                ErrorMessage = "�������� ����� �/��� ������. �� ���� ���������� ����������������!";
                ModelState.AddModelError(string.Empty, ErrorMessage);

                return Page();
            }

            //var password = _configuration.GetValue<string>("Secret:Password");
            //var email = _configuration.GetValue<string>("Secret:Login");
            //if(password!=null && email !=null && Input.Password !=password || Input.Email != email)
            //{
            //    ErrorMessage = "�������� ����� �/��� ������. �� ���� ���������� ����������������!";
            //    ModelState.AddModelError(string.Empty, ErrorMessage);

            //    return Page();
            //}

            var claims = new List<Claim>
        {
            new(ClaimTypes.Email,Input.Email),
            new(ClaimTypes.GivenName, Input.Email),
            new(ClaimTypes.NameIdentifier, Input.Email),
            new(ClaimTypes.Name, Input.Email),
            new(ClaimTypes.Role, "Administrator")
        };
            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);

            return Redirect(returnUrl);

        }
    }
}
