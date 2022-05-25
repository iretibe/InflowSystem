using InflowSystem.Shared.Abstractions.Auth;
using InflowSystem.Shared.Abstractions.Storage;

namespace InflowSystem.Modules.Users.Core.Services
{
    internal sealed class UserRequestStorage : IUserRequestStorage
    {
        private readonly IRequestStorage _requestStorage;

        public UserRequestStorage(IRequestStorage requestStorage)
        {
            _requestStorage = requestStorage;
        }

        public JsonWebToken GetToken(Guid commandId)
            => _requestStorage.Get<JsonWebToken>(GetKey(commandId));

        public void SetToken(Guid commandId, JsonWebToken jwt)
            => _requestStorage.Set(GetKey(commandId), jwt);

        private static string GetKey(Guid commandId) => $"jwt:{commandId:N}";
    }
}
