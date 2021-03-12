using AutoMapper;
using HotelListing.Dtos;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        //private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager,
                                 ILogger<AccountController> logger,IMapper mapper)
        {
            _userManager = userManager;
          //  _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            _logger.LogInformation($"Registeration attemp for {userDto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<ApiUser>(userDto);
                user.UserName = userDto.Email;
                var result = await _userManager.CreateAsync(user,userDto.Password);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                    return BadRequest(ModelState);
                }
                else
                {
                    return Accepted();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in {nameof(Register)} , {ex.Message}");
                return Problem($"Something went wrong in {nameof(Register)}", statusCode: 500);
            }
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginUserDto loginUser)
        //{
        //    _logger.LogInformation($"{loginUser.Email} start to login");
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, false);
        //        return Accepted();

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong in {nameof(Login)} , {ex.Message}");
        //        return Problem($"Something went wrong in {nameof(Login)}",statusCode:500);
        //    }
        //}
    }
}
