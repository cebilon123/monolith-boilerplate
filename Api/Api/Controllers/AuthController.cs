using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Handlers;
using Api.Application.Messages;
using Api.Attributes;
using Api.Infrastructure.Cqrs;
using Api.Infrastructure.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public AuthController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }
        
        [HttpPost]
        [Route("Register")]
        [SwaggerDescription("Register user.")]
        public async Task<ActionResult> Register()
        {
            return Ok();
        }
        
        [HttpGet]
        [Route("Login")]
        [SwaggerDescription("Login to application.")]
        public async Task<ActionResult> Login()
        {
            return Ok();
        }
        
        [HttpGet]
        [Route("Refresh")]
        [SwaggerDescription("Refresh token pair based on refresh token being send.")]
        public async Task<ActionResult> Refresh()
        {
            return Ok();
        }
    }
}