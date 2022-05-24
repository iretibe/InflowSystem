namespace InflowSystem.Modules.Customers.Core.DTO
{
    public class CustomerDetailDto : CustomerDto
    {
        public IdentityDto Identity { get; set; }

        public string? Address { get; set; }
        public string? Notes { get; set; }
    }
}
