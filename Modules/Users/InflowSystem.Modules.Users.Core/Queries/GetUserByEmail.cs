using InflowSystem.Modules.Users.Core.DTO;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Modules.Users.Core.Queries
{
    internal class GetUserByEmail : IQuery<UserDetailsDto>
    {
        public string Email { get; set; }
    }
}
