using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("InflowSystem.Modules.Payments.Core")]
namespace InflowSystem.Modules.Payments.Shared.Entities
{
    internal class Customer
    {
        public Guid Id { get; private set; }
        public FullName FullName { get; private set; }
        public Nationality Nationality { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsVerified { get; private set; }

        private Customer()
        {
        }

        public Customer(Guid id, FullName fullName, Nationality nationality)
        {
            Id = id;
            FullName = fullName;
            Nationality = nationality;
            IsActive = true;
        }

        public void Verify() => IsVerified = true;

        public bool Lock() => IsActive = false;

        public bool Unlock() => IsActive = true;
    }
}
