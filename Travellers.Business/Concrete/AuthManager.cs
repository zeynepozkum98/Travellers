using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Business.Abstract;
using Travellers.Business.ValidationRules.FluentValidation;
using Travellers.Entities.Concrete;

namespace Travellers.Business.Concrete
{
    public class AuthManager : IAuthService
    {
         UserManager<AppUser> _userManager { get; set; }
        RoleManager<AppRole> _roleManager { get; set; }
        SignInManager<AppUser> _signInManager { get; set; }
        IMapper _mapper { get; set; }

        public AuthManager(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager,IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        UserManager<AppUser> IAuthService._userManager { get => _userManager; set => value = _userManager; }
        RoleManager<AppRole> IAuthService._roleManager { get => _roleManager; set => value = _roleManager; }
        SignInManager<AppUser> IAuthService._signInManager { get => _signInManager; set => value = _signInManager; }
        IMapper IAuthService._mapper { get => _mapper; set => value = _mapper; }
    }
}
