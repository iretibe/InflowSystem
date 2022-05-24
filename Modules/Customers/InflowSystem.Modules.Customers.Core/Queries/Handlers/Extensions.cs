using InflowSystem.Modules.Customers.Core.Domain.Entities;
using InflowSystem.Modules.Customers.Core.DTO;

namespace InflowSystem.Modules.Customers.Core.Queries.Handlers
{
    internal static class Extensions
    {
        public static CustomerDto AsDto(this Customer customer)
            => customer.Map<CustomerDto>();

        public static CustomerDetailDto AsDetailDto(this Customer customer)
        {
            var dto = customer.Map<CustomerDetailDto>();
            dto.Address = customer.Address;
            dto.Notes = customer.Notes;
#pragma warning disable CS8601 // Possible null reference assignment.
            dto.Identity = customer.Identity is null ? null : new IdentityDto
            {
                Type = customer.Identity.Type,
                Series = customer.Identity.Series
            };
#pragma warning restore CS8601 // Possible null reference assignment.

            return dto;
        }

        private static T Map<T>(this Customer customer) where T : CustomerDto, new()
            => new()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                FullName = customer.FullName,
                Nationality = customer.Nationality,
                IsActive = customer.IsActive,
                CreatedAt = customer.CreatedAt
            };
    }
}
