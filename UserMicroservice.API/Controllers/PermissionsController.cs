using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.API.Database;
using UserMicroservice.API.Database.Repositories;
using UserMicroservice.API.Requests;
using UserMicroservice.API.Requests.Queries.Permissions;
using UserMicroservice.Data.Transfer.ViewModels.Permissions;

namespace UserMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    public class PermissionsController : Controller
    {
        IQueryHandler<GetPermissionsQuery, PermissionListViewModel> _getAllPermsHandler;

        public PermissionsController(
            IQueryHandler<GetPermissionsQuery, PermissionListViewModel> getAllPermsHandler)
        {
            _getAllPermsHandler = getAllPermsHandler;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get(GetPermissionsQuery query)
        {
            var res = _getAllPermsHandler.Execute(query);
            return Ok(res);
        }
    }
}
