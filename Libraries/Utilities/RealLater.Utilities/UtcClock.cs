using System;

namespace ReadLater.Utilities
{
    public class UtcClock : IClock
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
