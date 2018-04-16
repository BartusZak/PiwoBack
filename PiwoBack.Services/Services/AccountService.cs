using AutoMapper;
using PiwoBack.Data.DTOs;
using PiwoBack.Data.Models;
using PiwoBack.Data.ViewModels;
using PiwoBack.Repository.Interfaces;
using PiwoBack.Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace PiwoBack.Services.Services
{
    public class AccountService: IAccountService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IConfigurationManager _configuration;
        private readonly IMapper _mapper;

        public AccountService(IRepository<User> userRepository, IConfigurationManager configuration, IMapper mapper, IRepository<UserRole> userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public ResultDto<RegisterDto> Register(RegisterViewModel registerModel)
        {
            var result = new ResultDto<RegisterDto>();
            if (_userRepository.Exist(x => x.Email == registerModel.Email))
            {
                result.Errors.Add("Podany adres email jest już używany.");
                return result;
            }
            if (_userRepository.Exist(x => x.Username == registerModel.Username))
            {
                result.Errors.Add("Podana nazwa użytkownika jest już używana.");
                return result;
            }// jeden return wszytskie bledy

            var user = _mapper.Map<User>(registerModel);
            user.PasswordHash = GetHash(registerModel.Password);
            user.RegisterDate = DateTime.Now;
            user.Role = _userRoleRepository.GetBy(x => x.Id == 1);

            _userRepository.Insert(user);
            result.SuccessResult = _mapper.Map<RegisterDto>(user);

            return result;
        }

        public ResultDto<LoginDto> Login(LoginViewModel loginModel)
        {
            var result = new ResultDto<LoginDto>();
            var user = _userRepository.GetBy(x => x.Username == loginModel.Username);

            if (user?.PasswordHash != GetHash(loginModel.Password))
            {
                result.Errors.Add("Błędny login lub hasło.");
                return result;
            }


            var loginDto = _mapper.Map<LoginDto>(user);
            loginDto.Token = GetToken(user, _configuration.GetValue("Jwt:Key"), _configuration.GetValue("Jwt:Issuer"), DateTime.Now.AddHours(2)); ;
            result.SuccessResult = loginDto;
            return result;
        }

        private string GetHash(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        private string GetToken(User user, string secretKey, string issuer, DateTime? expirationDate = null)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.GivenName, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
            };
            var token = new JwtSecurityToken(issuer, issuer, claims, expires: expirationDate, signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
