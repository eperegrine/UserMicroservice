using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.API.Database.Repositories;
using UserMicroservice.API.Requests.Queries.Users.Authentication;
using UserMicroservice.Data;
using UserMicroservice.Data.Models;
using UserMicroservice.Data.Transfer.ViewModels.User;

namespace UserMicroservice.API.Requests.Handlers.Users.Authentication
{
    public class LoginHandler : IQueryHandler<LoginQuery, AuthTokenDTO>
    {
        UserRepository _repo;

        public LoginHandler(UserRepository repo)
        {
            _repo = repo;
        }

        public AuthTokenDTO Execute(LoginQuery query)
        {
            if (!Validator.IsValidEmail(query.Email))
            {
                return AuthTokenDTO.GenerateError("Invalid Email");
            }

            if (!Validator.IsValidPassword(query.Password))
            {
                return AuthTokenDTO.GenerateError("Invalid Password");
            }

            IQueryable<User> users = _repo.AsQuerable();

            User u;

            try
            {
                u = users.First(x => x.Email == query.Email);
            }
            catch (Exception e)
            {
                return AuthTokenDTO.GenerateError("Wrong email/password");
            }

            var salt = u.Salt;

            bool correctPassword = PasswordHashing.ComparePasswords(query.Password, salt, u.Password);

            if (correctPassword)
            {
                DateTime expDate = DateTime.Now.AddDays(1);
                string authToken = PasswordHashing.GenerateHash(
                    password: u.Password + expDate,
                    salt: u.Salt, 
                    iterationCount: 100
                );

                var res = _repo.Update(u.Id, x => {
                    x.AuthToken = authToken;
                    x.AuthTokenExpiration = expDate;
                    return x;
                });

                if (res.Success)
                {
                    return new AuthTokenDTO()
                    {
                        Success = true,
                        AuthToken = authToken
                    };
                }

                return AuthTokenDTO.GenerateError(res.ErrorMessage);
            }
            else
            {
                return AuthTokenDTO.GenerateError("Erong email/password");
            }
        }
    }
}
