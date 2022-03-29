using InflowSystem.Shared.Abstractions.Time;

namespace InflowSystem.Shared.Infrastructure.Time
{
    public class UtcClock : IClock
    {
        public DateTime CurrentDate() => DateTime.UtcNow;
    }
}
