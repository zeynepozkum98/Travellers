using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Traveller.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        IOrderProcessService _orderProcessService;



        public AccountController(IAuthService authService,IOrderProcessService orderProcessService)
        {
            _authService = authService;
            _orderProcessService = orderProcessService;
           
        }
      

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if(ModelState.IsValid)
            {
                string ass = User.Identity.Name;
                var result = await _authService.Login(loginDto);

                if(result.Succeeded)
                {
                    var user = _authService.GetUserByEmail(loginDto.Email);
                    var role = await _authService.GetRoleByUserName(user.UserName);
                   

                    switch(role)
                    {
                        case "User": return RedirectToAction("WinterHoliday","Tour");
                        default: return RedirectToAction("WinterHoliday","Tour");
                    }
                }
            }

            ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz!");
            return View(loginDto);
        }

      

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result= await _authService.Register(registerDto);
            if(result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _authService.Logout();
            return RedirectToAction("Login");
        }

        

    }
}
