using Application.Helpers;
using Application.IServices;
using Application.ViewModels.UserViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Security.Claims;

namespace VinsportWebAPI.Controllers
{
    [ApiController]
    [Route("odata/[controller]")]

    public class UserController : ODataController
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        #region Add New User
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                var userObj = await _userService.AddUser(user);
                return Ok(userObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Get User By ID
        [Authorize()]
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Invalid parameters");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("Not found");
            }
        }
        #endregion

        #region Get User List
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            try
            {
                var user = await _userService.GetUserList();
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error");
            }
        }
        #endregion

        #region Update User
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood(User user)
        {
            try
            {
                var result = await _userService.UpdateUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Update Failed");
            }
        }
        #endregion

        #region Login with email and password hashed
        [HttpPost("login")]
        public async Task<IActionResult> LoginAndGenerateToken(UserLoginVM userLoginVM)
        {
            try
            {
                ClaimsPrincipal claimsPrincipal;
                var result = await _userService.LoginAndGenerateToken(userLoginVM.Email, userLoginVM.Password);
                var tokenValidated = JWTHelpers.ValidateToken(result.Item1, _configuration, out claimsPrincipal);
                return Ok(new
                {
                    Token = result.Item1,
                    UserInfo = new
                    {
                        result.Item2.FullName,
                        result.Item2.Email,
                        result.Item2.Role,
                        result.Item2.Id,
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest("Login Failed");
            }
        }
        #endregion
        

        #region Get current user
        [HttpPost("me")]
        public async Task<IActionResult> GetCurrentLoginUser([FromBody] CurrentUserTokenVM currentUser)
        {
            try
            {
                ClaimsPrincipal claimsPrincipal;
                var tokenValidated = JWTHelpers.ValidateToken(currentUser.UserToken, _configuration, out claimsPrincipal);
                if (claimsPrincipal == null) throw new Exception("Invalid claims");
                var claims = new
                {
                    ID = claimsPrincipal.FindFirst("UserId").Value,
                    Email = claimsPrincipal.FindFirst("Email").Value,
                    Name = claimsPrincipal.FindFirst("Name").Value,
                    Role = claimsPrincipal.FindFirst("Role").Value,

                };
                return Ok(claims);
            }
            catch (Exception ex)
            {
                return BadRequest("Login Failed");
            }
        }
        #endregion
    }
}
