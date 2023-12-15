using Identity.Domain.Identity;
using Identity.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Identity.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IToastNotification _toastNotification;

        public AuthController(UserManager<User> userManager, IToastNotification toastNotification )
        {
            _userManager = userManager;
            _toastNotification = toastNotification;

        }

    public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var registerViewModel = new AuthRegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(AuthRegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);

            var userId = Guid.NewGuid();

            var user = new User()
            {
                Id = userId,
                Email = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                SurName = registerViewModel.SurName,
                Gender = registerViewModel.Gender,
                BirthDate = registerViewModel.BirthDate.Value.ToUniversalTime(),
                UserName = registerViewModel.UserName,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = userId.ToString()
            };

            var identityResult = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return View(registerViewModel);
            }


            _toastNotification.AddSuccessToastMessage("Success");

            return RedirectToAction(nameof(Login));


        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var loginViewModel = new AuthLoginViewModel();

            return View(loginViewModel);
        }


    }
}
