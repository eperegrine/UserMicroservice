using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.API.Requests;
using UserMicroservice.API.Requests.Queries.Users.Authentication;
using UserMicroservice.Data.Transfer.ViewModels.User;
using UserMicroservice.Data.Transfer;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UserMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        IQueryHandler<LoginQuery, AuthTokenDTO> _loginHandler;
        IQueryHandler<RegisterQuery, AddDTO> _registerHandler;

        public AuthController(
            IQueryHandler<LoginQuery, AuthTokenDTO> loginHandler,
            IQueryHandler<RegisterQuery, AddDTO> registerHandler)
        {
            _loginHandler = loginHandler;
            _registerHandler = registerHandler;
        }

        // GET: api/values/login
        [HttpGet("Login")]
        public IActionResult Login([FromBody]LoginQuery query)
        {
            return Ok(_loginHandler.Execute(query));
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody]RegisterQuery query)
        {
            return Ok(_registerHandler.Execute(query));
        }
    }
}
