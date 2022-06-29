using InflowSystem.Shared.Abstractions.Kernel.ValueObjects;

namespace InflowSystem.Modules.Payments.Core.Deposits.Domain.Services
{
    internal interface ICurrencyResolver
    {
        Currency GetForNationality(Nationality nationality);
    }
}
