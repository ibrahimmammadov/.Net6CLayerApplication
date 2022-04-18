using Core.DTOs;
using Core.DTOsToken;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAuthenticationService
    {
        Task<CResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        Task<CResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken);

        Task<CResponseDto<bool>> RevokeRefreshToken(string refreshToken);

        CResponseDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
    }
}