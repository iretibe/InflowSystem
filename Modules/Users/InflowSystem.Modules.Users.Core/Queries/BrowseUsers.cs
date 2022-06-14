using InflowSystem.Modules.Users.Core.DTO;

namespace InflowSystem.Modules.Users.Core.Queries
{
    internal class BrowseUsers : PagedQuery<UserDto>
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string State { get; set; }
    }
}
