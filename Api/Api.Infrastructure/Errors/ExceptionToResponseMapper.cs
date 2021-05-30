using System;
using System.Diagnostics;
using System.Net;
using Api.Domain.Exceptions;
using ApplicationException = Api.Application.Exceptions.ApplicationException;

namespace Api.Infrastructure.Errors
{
    public class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public Error GetErrorBasedOnException(Exception exception) =>
            exception switch
            {
                ApplicationException ex => HandleApplicationException(ex),
                DomainException ex => HandleDomainException(ex),
                _ => new Error("Error", "Generic error", HttpStatusCode.InternalServerError)
            };

        private Error HandleApplicationException(ApplicationException exception)
            => exception switch
            {
                _ => new Error("Domain_exception", "Error occured while parsing domain object",
                    HttpStatusCode.InternalServerError)
            };

        private Error HandleDomainException(DomainException exception)
            => exception switch
            {
                _ => new Error("Application_exception", "Error occured while making request",
                    HttpStatusCode.BadRequest)
            };
    }
}