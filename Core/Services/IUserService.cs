using Core.DTOs;
using Core.DTOsToken;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task<CResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<CResponseDto<UserAppDto>> GetUserByNameAsync(string userName);
    }
}