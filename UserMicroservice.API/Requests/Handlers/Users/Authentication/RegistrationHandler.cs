using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.API.Database.Repositories;
using UserMicroservice.API.Requests.Queries.Users.Authentication;
using UserMicroservice.Data.Transfer;
using UserMicroservice.Data;
using UserMicroservice.Data.Models;

namespace UserMicroservice.API.Requests.Handlers.Users.Authentication
{
    public class RegistrationHandler : IQueryHandler<RegisterQuery, AddDTO>
    {
        UserRepository _userRepo;
        PermissionRepository _permRepo;

        public RegistrationHandler(
            UserRepository userRepo, PermissionRepository permRepo)
        {
            _userRepo = userRepo;
            _permRepo = permRepo;
        }

        public AddDTO Execute(RegisterQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.Username))
            {
                return AddDTO.GenerateError("Invalid Username");
            }

            if (!Validator.IsValidEmail(query.Email))
            {
                return AddDTO.GenerateError("Invalid Email");
            }

            if (!Validator.IsValidPassword(query.Password))
            {
                return AddDTO.GenerateError("Invalid Password");
            }

            var salt = PasswordHashing.GenerateSalt();

            var hashedPassword = PasswordHashing.GenerateHash(query.Password, salt);

            var permission = _permRepo.GetInititialPermission();

            if (permission == null)
            {
                return AddDTO.GenerateError("Server Error: could not find initial permission");
            }

            User user = new User()
            {
                Email = query.Email,
                Username = query.Username,
                Permissions = permission,
                Salt = salt,
                Password = hashedPassword
            };

            AddDTO res = _userRepo.Create(user);

            return res;
        }
    }
}
