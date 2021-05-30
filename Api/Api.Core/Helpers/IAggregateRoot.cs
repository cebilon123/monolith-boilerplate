using System;

namespace Api.Domain.Helpers
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}