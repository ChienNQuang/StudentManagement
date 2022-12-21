using AutoMapper;
using StudentManagement.API.Models;
using StudentManagement.API.Services;
using StudentManagement.API.TokenAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Controllers.Payloads.Requests;
using StudentManagement.API.Models.Entities;

namespace StudentManagement.API.Controllers
{
    [Produces("application/json")]
    [Authorize()]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly ITokenManager _tokenManager;
        private readonly IMapper _mapper;

        public AuthenticateController(ITokenManager tokenManager, IMapper mapper)
        {
            _tokenManager = tokenManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Log user in and return a token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCode.)]
        [HttpPost]
        public ActionResult<User> Authenticate(AuthenticateRequestModel model)
        {
            User user = _tokenManager.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest(new { Message = "Your username or password is incorrect"});
            }

            return Ok(_mapper.Map<User>(user));

        }
    }
}