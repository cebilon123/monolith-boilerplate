using System;
using Api.Application.Exceptions;

namespace Api.Infrastructure.Errors
{
    public interface IExceptionToResponseMapper
    {
        Error GetErrorBasedOnException(Exception exception);
    }
}