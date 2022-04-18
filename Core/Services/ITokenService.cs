using Core;
using Core.Configuration;
using Core.DTOsToken;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);

        ClientTokenDto CreateTokenByClient(Client client);
    }
}