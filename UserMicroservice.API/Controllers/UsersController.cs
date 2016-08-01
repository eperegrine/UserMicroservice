using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.API.Database;
using UserMicroservice.API.Database.Repositories;
using UserMicroservice.API.Requests;
using UserMicroservice.API.Requests.Queries.Users;
using UserMicroservice.Data.Transfer.ViewModels.User;

namespace UserMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        IQueryHandler<GetUsersQuery, UserListViewModel> _getUserHandler;

        public UsersController(
            IQueryHandler<GetUsersQuery, UserListViewModel> getUserHandler)
        {
            _getUserHandler = getUserHandler;
        }

        // GET api/users
        [HttpGet]
        public IActionResult Get(GetUsersQuery query)
        {
            var res = _getUserHandler.Execute(query);
            return Ok(res);
        }
    }
}
