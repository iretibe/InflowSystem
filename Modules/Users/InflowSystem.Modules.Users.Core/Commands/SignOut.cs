using InflowSystem.Shared.Abstractions.Commands;

namespace InflowSystem.Modules.Users.Core.Commands
{
    internal record SignOut(Guid UserId) : ICommand;
}
