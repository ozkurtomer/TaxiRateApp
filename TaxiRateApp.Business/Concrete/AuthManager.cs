﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Business.Constants;
using TaxiRateApp.Core.Extensions;
using TaxiRateApp.Core.Utilities.Results.Abstract;
using TaxiRateApp.Core.Utilities.Results.Concrete;
using TaxiRateApp.Core.Utilities.Security;
using TaxiRateApp.Core.Utilities.Security.Hashing;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Entities.Dtos;

namespace TaxiRateApp.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private ITokenHelper _tokenHelper;
        private IUsersService _usersService;

        public AuthManager(ITokenHelper tokenHelper, IUsersService usersService)
        {
            _tokenHelper = tokenHelper;
            _usersService = usersService;
        }

        public IDataResult<Users> Login(UserForLoginDto userForLoginDto)
        {
            var user = _usersService.GetByName(userForLoginDto.UserName);
            if (user.Data != null)
            {
                if (!HashingHelper.VerifyPasswordHash(userForLoginDto.UserPassword, user.Data.User_PasswordHash.ToHexBytes(), user.Data.User_PasswordSalt.ToHexBytes()))
                {
                    return new ErrorDataResult<Users>(Messages.UserPasswordError);
                }

                return new SuccessDataResult<Users>(user.Data, Messages.SuccessfulLogin);
            }
            return new ErrorDataResult<Users>(Messages.WrongUserName);
        }

        public IDataResult<AccessToken> CreateAccessToken(Users users)
        {
            var accessToken = _tokenHelper.CreateToken(users);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            var result = _usersService.GetByName(userForRegisterDto.UserUserName);
            if (result.Data != null)
            {
                return new ErrorDataResult<Users>( Messages.UserAlreadyExits);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            byte[] saltByte = passwordSalt;

            var users = new Users
            {
                User_Name = userForRegisterDto.UserName,
                User_PasswordHash = passwordHash.ToHexString(),
                User_PasswordSalt = passwordSalt.ToHexString(),
                User_Email = userForRegisterDto.UserEmail,
                User_CreatedDate = DateTime.Now,
                User_UserName = userForRegisterDto.UserUserName,
                User_Ip = "12341232",
                User_Anonymous = userForRegisterDto.UserAnonymous,
                User_IsActive = false,
            };
            _usersService.Add(users);
            return new SuccessDataResult<Users>(users, Messages.UserRegistered);
        }
    }
}