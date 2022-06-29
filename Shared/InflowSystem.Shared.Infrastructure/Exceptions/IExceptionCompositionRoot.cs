using InflowSystem.Shared.Abstractions.Exceptions;

namespace InflowSystem.Shared.Infrastructure.Exceptions
{
    internal interface IExceptionCompositionRoot
    {
        ExceptionResponse Map(Exception exception);
    }
}
