using InflowSystem.Shared.Abstractions.Commands;
using System.ComponentModel.DataAnnotations;

namespace InflowSystem.Modules.Users.Core.Commands
{
    internal record SignIn([Required][EmailAddress] string Email, [Required] string Password) : ICommand
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
