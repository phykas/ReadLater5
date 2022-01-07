using System;

namespace ReadLater.Utilities
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}
