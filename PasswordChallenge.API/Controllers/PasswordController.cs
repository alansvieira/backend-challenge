using PasswordChallenge.Core.Entities;
using PasswordChallenge.Core.Services;
using PasswordChallenge.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly ILogger<PasswordController> _logger;

        public PasswordController(ILogger<PasswordController> logger)
        {
            _logger = logger;
        }
        
        
        [HttpPost]
        public Password CreatePassword([FromBody]string password)
        {
            try
            {
                return new PasswordService().CreatePassword(password, new CharactersModule());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw ex;
            }
            
        }
    }
}
