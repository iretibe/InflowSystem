using InflowSystem.Shared.Abstractions.Commands;

namespace InflowSystem.Modules.Users.Core.Commands
{
    internal record ChangePassword(Guid UserId, string CurrentPassword, string NewPassword) : ICommand;
}
