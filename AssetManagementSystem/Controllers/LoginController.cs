using AssetManagementSystem.Models;
using AssetManagementSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //dependency Injection for configuration
        private IConfiguration _config;
        ILoginRepository loginRepository;

        //1
        public LoginController(IConfiguration config, ILoginRepository log)
        {
            _config = config;
            loginRepository = log;
        }


        [AllowAnonymous]    //without Authorization
        [HttpGet("{userName}/{password}")]
        //[Route("GetToken")]
        //[AllowAnonymous]
        //LoginMethod -- IActionResult
        public IActionResult Login(string userName, string password)
        {
            IActionResult response = Unauthorized();

            //Authenticate The User
            var dbuser = AuthenticateUser(userName, password);

            //Validate
            if (dbuser != null)
            {
                var tokenString = GenerateJsonWebToken();
                response = Ok(new
                {
                    uname = dbuser.Username,
                    UserType = dbuser.UserType,
                    token = tokenString
                });
            }
            return response;
        }

        //GenerateJsonWebToken
        private object GenerateJsonWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //Signin Credential
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Generate token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Login AuthenticateUser(string userName, string password)
        {
            try
            {
                var user = loginRepository.verifyUser(userName, password);
                if (user == null)
                {
                    return null;
                }
                return user;
            }

            catch (Exception)
            {

                return null;
            }
        }


        #region For Testing ONLY     
        //[AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("getuser/{userName}/{password}")]
        public async Task<ActionResult<Login>> GetUserByNamePassword(string userName, string password)
        {
            try
            {
                var user = await loginRepository.GetUSerByPassword(userName, password);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }

            catch (Exception)
            {

                return BadRequest();
            }
        }
        #endregion
    }
}
