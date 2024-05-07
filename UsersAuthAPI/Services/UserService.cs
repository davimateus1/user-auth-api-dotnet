using AutoMapper;
using UsersAuthAPI.Models;
using UsersAuthAPI.Data.DTOs;
using Microsoft.AspNetCore.Identity;

namespace UsersAuthAPI.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Register(CreateUserDTO createUserDTO)
        {
            User user = _mapper.Map<User>(createUserDTO);

            IdentityResult result = await _userManager.CreateAsync
                (user, createUserDTO.Password);

            if (!result.Succeeded)
            {
                throw new ApplicationException("An error occurred while registering the user");
            }
        }

        public async Task<string> Login(LoginUserDTO loginUserDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(
                loginUserDTO.Username, 
                loginUserDTO.Password, false, false);

            if (!result.Succeeded)
            {
                throw new ApplicationException("User not authenticated!");
            }

            var user = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => 
                    user.NormalizedUserName == 
                    loginUserDTO.Username.ToUpper()) 
                ?? throw new ApplicationException("User not found!");

            var token = _tokenService.GenerateToken(user);

            return token;
        }
    }
}
