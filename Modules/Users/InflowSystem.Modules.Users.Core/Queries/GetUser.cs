using InflowSystem.Modules.Users.Core.DTO;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Modules.Users.Core.Queries
{
    internal class GetUser : IQuery<UserDetailsDto>
    {
        public Guid UserId { get; set; }
    }
}
