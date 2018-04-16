using PiwoBack.Data.DTOs;
using PiwoBack.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PiwoBack.Services.Interfaces
{
    public interface IAccountService
    {
        ResultDto<RegisterDto> Register(RegisterViewModel registerModel);
        ResultDto<LoginDto> Login(LoginViewModel loginModel);
        //ResultDto<ProfilePictureDto> AddAvatar(IFormFile avatar, int userId);
        //ResultDto<UserDto> ChangePassword(ChangePasswordViewModel changePasswordViewModel, int userId);
        //ResultDto<UserDto> UpdateUserData(UserViewModel userViewModel, int userId);
    }
}
