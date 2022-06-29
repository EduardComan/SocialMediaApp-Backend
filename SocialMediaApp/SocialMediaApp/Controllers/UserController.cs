using SocialMediaApp.DataLayer.Entities;
using SocialMediaApp.Services;
using SocialMediaApp.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialMediaApp.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : WebApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerAuthService _authorization;

        public UserController(IUnitOfWork unitOfWork, ICustomerAuthService authorization)
        {
            _unitOfWork = unitOfWork;
            _authorization = authorization;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<bool>> Register([FromBody] UserDto request)
        {
            if (request == null)
            {
                return BadRequest(error: "Request must not be empty!");
            }

            var hashedPassword = _authorization.HashPassword(request.Password);

            var user = new User()
            {
                Username = request.Username,
                Email = request.Email,
                Password = hashedPassword,
            };

            _unitOfWork.Users.Insert(user);
            var saveResult = await _unitOfWork.SaveChangesAsync();

            return Ok(saveResult);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<ResponseLogin> Login([FromBody] RequestLogin request)
        {
            var user = _unitOfWork.Users.GetUserByEmail(request.Email);
            if (user == null) return BadRequest("User not found!");

            var samePassword = _authorization.VerifyHashedPassword(user.Password, request.Password);
            if (!samePassword) return BadRequest("Invalid password!");

            var user_jsonWebToken = _authorization.GetToken(user);

            return Ok(new ResponseLogin
            {
                Token = user_jsonWebToken
            });
        }


        [HttpGet]
        [Route("all")]
        public ActionResult<List<LightUserDto>> GetAll()
        {
            var users = _unitOfWork.Users.GetAll(includeDeleted: false).Select(u => new LightUserDto
            {
                Username = u.Username,
                Email = u.Email,
            });
            return Ok(users);
        }

        [HttpGet]
        [Route("my-account")]
        [Authorize(Roles = "User")]
        public ActionResult<bool> MyAccount()
        {
            var userId = GetUserId();
            if (userId == null) return Unauthorized();

            var user = _unitOfWork.Users.GetUserByIdWithNotifications((Guid)userId);
            //var notifications = user.Notifications
            //    .Select(notif =>
            //        new NotificationDto
            //        {
            //            Title = notif.Title,
            //            Description = notif.Description
            //        }
            //    ).ToList();

            return Ok(new UserDto
            {
                Username = user.Username,
                Email = user.Email,
            });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("delete/all")]
        public async Task<ActionResult<List<User>>> DeleteAll()
        {
            var users = _unitOfWork.Users.GetAll().ToList();

            foreach (var user in users)
            {
                _unitOfWork.Users.Delete(user);
            }
            await _unitOfWork.SaveChangesAsync();
            return Ok(users);
        }
    }
}
