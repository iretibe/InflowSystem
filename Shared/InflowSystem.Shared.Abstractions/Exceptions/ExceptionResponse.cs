using System.Net;

namespace InflowSystem.Shared.Abstractions.Exceptions
{
    public record ExceptionResponse(object Response, HttpStatusCode StatusCode);
}
