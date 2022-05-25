using InflowSystem.Shared.Abstractions.Auth;

namespace InflowSystem.Modules.Users.Core.Services
{
    internal interface IUserRequestStorage
    {
        void SetToken(Guid commandId, JsonWebToken jwt);
        JsonWebToken GetToken(Guid commandId);
    }
}
