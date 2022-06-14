using InflowSystem.Shared.Abstractions.Commands;
using System.ComponentModel.DataAnnotations;

namespace InflowSystem.Modules.Users.Core.Commands
{
    internal record SignUp([Required][EmailAddress] string Email, [Required] string Password, string Role) : ICommand
    {
        public Guid UserId { get; init; } = Guid.NewGuid();
    }
}
