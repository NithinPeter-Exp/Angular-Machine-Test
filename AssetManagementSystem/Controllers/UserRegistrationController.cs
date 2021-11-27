using AssetManagementSystem.Models;
using AssetManagementSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        //Constructor Dependency Injection for UserRegistrationRepository        
        IUserRegistrationRepository userRepository;
        public UserRegistrationController(IUserRegistrationRepository _p)
        {
            userRepository = _p;
        }

        #region Http Get functions get all and get by id        
        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            try
            {
                var users = await userRepository.GetUser();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public Task<ActionResult<UserRegistration>> GetUserById(int id)
        {
            try
            {
                var user = userRepository.GetUserById(id);
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

        #endregion

        #region Add User
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserRegistration model)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await userRepository.AddUser(model);
                    if (userId > 0)
                    {
                        return Ok(userId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Update Client
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserRegistration model)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await userRepository.UpdateUser(model);
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Delete User
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await userRepository.DeleteUser(id);
                    return Ok(id);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion
    }
}
