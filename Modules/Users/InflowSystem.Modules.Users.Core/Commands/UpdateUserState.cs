using InflowSystem.Shared.Abstractions.Commands;

namespace InflowSystem.Modules.Users.Core.Commands
{
    internal record UpdateUserState(Guid UserId, string State) : ICommand;
}
